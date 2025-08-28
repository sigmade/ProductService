using Core.Contracts.DiscountClient;
using Core.Contracts.DiscountClient.Models;
using Core.Contracts.ProductRepository;
using Core.Contracts.ProductRepository.Models;
using Core.UseCases.GetProduct;
using Core.UseCases.GetProduct.Models;
using NSubstitute;

namespace CoreUnitTests.UseCases.GetProduct;

public class GetProductUseCaseTests
{
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();
    private readonly IDiscountClient _discountClient = Substitute.For<IDiscountClient>();

    private GetProductUseCase CreateSut() => new(_productRepository, _discountClient);

    private static ProductDataResult BuildProductDataResult(decimal basePrice = 100m) => new()
    {
        Id = 1,
        Name = "Test Product",
        BasePrice = basePrice
    };

    private static DiscountDataResult BuildDiscount(decimal value) => new() { DiscountValue = value };

    [Fact]
    public async Task Execute_NoDiscountApplied_WhenDiscountIsZero()
    {
        var query = new ProductQuery { Id = 1 };

        _productRepository.GetById(Arg.Any<ProductDataQuery>())
            .Returns(ci => BuildProductDataResult(200m));
        _discountClient.GetDiscountForProduct(Arg.Any<DiscountDataQuery>())
            .Returns(ci => BuildDiscount(0m));

        var sut = CreateSut();

        var result = await sut.Execute(query);

        Assert.Equal(200m, result.Price);
    }

    [Fact]
    public async Task Execute_AppliesDiscount_WhenBetweenZeroAndOne()
    {
        var query = new ProductQuery { Id = 5 };

        _productRepository.GetById(Arg.Any<ProductDataQuery>())
            .Returns(ci => BuildProductDataResult(100m));
        _discountClient.GetDiscountForProduct(Arg.Any<DiscountDataQuery>())
            .Returns(ci => BuildDiscount(0.25m)); // 25% off

        var sut = CreateSut();

        var result = await sut.Execute(query);

        Assert.Equal(75m, result.Price); // 100 * (1-0.25)
    }

    [Fact]
    public async Task Execute_DoesNotApplyDiscount_WhenNegative()
    {
        var query = new ProductQuery { Id = 2 };

        _productRepository.GetById(Arg.Any<ProductDataQuery>())
            .Returns(ci => BuildProductDataResult(50m));
        _discountClient.GetDiscountForProduct(Arg.Any<DiscountDataQuery>())
            .Returns(ci => BuildDiscount(-0.1m));

        var sut = CreateSut();

        var result = await sut.Execute(query);

        Assert.Equal(50m, result.Price);
    }

    [Fact]
    public async Task Execute_DoesNotApplyDiscount_WhenGreaterOrEqualOne()
    {
        var query = new ProductQuery { Id = 3 };

        _productRepository.GetById(Arg.Any<ProductDataQuery>())
            .Returns(ci => BuildProductDataResult(80m));
        _discountClient.GetDiscountForProduct(Arg.Any<DiscountDataQuery>())
            .Returns(ci => BuildDiscount(1m)); // 100% should be ignored per logic (>0 && <1)

        var sut = CreateSut();

        var result = await sut.Execute(query);

        Assert.Equal(80m, result.Price);
    }

    [Fact]
    public async Task Execute_RoundsToTwoDecimals_AfterDiscount()
    {
        var query = new ProductQuery { Id = 10 };

        _productRepository.GetById(Arg.Any<ProductDataQuery>())
            .Returns(ci => BuildProductDataResult(123.456m));
        _discountClient.GetDiscountForProduct(Arg.Any<DiscountDataQuery>())
            .Returns(ci => BuildDiscount(0.1337m));

        var sut = CreateSut();

        var result = await sut.Execute(query);

        // price = 123.456 * (1 - 0.1337) = 123.456 * 0.8663 = 106.9499328 -> rounded 106.95
        Assert.Equal(106.95m, result.Price);
    }

    [Fact]
    public async Task Execute_UsesQueryId_ForRepositoryAndDiscountCalls()
    {
        var query = new ProductQuery { Id = 42 };
        _productRepository.GetById(Arg.Any<ProductDataQuery>())
            .Returns(BuildProductDataResult());
        _discountClient.GetDiscountForProduct(Arg.Any<DiscountDataQuery>())
            .Returns(BuildDiscount(0m));

        var sut = CreateSut();
        await sut.Execute(query);

        await _productRepository.Received(1).GetById(Arg.Is<ProductDataQuery>(q => q.Id == 42));
        await _discountClient.Received(1).GetDiscountForProduct(Arg.Is<DiscountDataQuery>(q => q.ProductId == 42));
    }
}
