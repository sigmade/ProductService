using Core.Contracts;
using Core.Models;
using Core.UseCases.GetProduct;
using NSubstitute;

namespace CoreUnitTests.UseCases;

public class GetProductUseCaseTests
{
    [Fact]
    public async Task Execute_Returns_Product_From_Repository()
    {
        // Arrange
        var repo = Substitute.For<IProductRepository>();
        var expected = new Product { Id = 1, Name = "Test", Price = 9.99m };
        repo.GetById(1).Returns(expected);
        var sut = new GetProductUseCase(repo);

        // Act
        var result = await sut.Execute(1);

        // Assert
        Assert.Same(expected, result);
        await repo.Received(1).GetById(1);
    }

    [Fact]
    public async Task Execute_Passes_Id_To_Repository()
    {
        // Arrange
        var repo = Substitute.For<IProductRepository>();
        var sut = new GetProductUseCase(repo);

        // Act
        _ = await sut.Execute(42);

        // Assert
        await repo.Received(1).GetById(42);
    }
}
