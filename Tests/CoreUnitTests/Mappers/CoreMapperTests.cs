using Core;
using Core.Contracts.ProductRepository.Models;
using Core.UseCases.GetProduct.Models;

namespace CoreUnitTests.Mappers;

public class CoreMapperTests
{
    [Fact]
    public void ToResult_Maps_All_Fields()
    {
        var data = new ProductDataResult
        {
            Id = 7,
            Name = "Widget",
            BasePrice = 123.45m
        };

        var result = data.ToResult();

        Assert.Equal(data.Id, result.Id);
        Assert.Equal(data.Name, result.Name);
        Assert.Equal(data.BasePrice, result.Price);
    }

    [Fact]
    public void ToProductDataQuery_Maps_Id()
    {
        var query = new ProductQuery { Id = 99 };

        var dataQuery = query.ToProductDataQuery();

        Assert.Equal(99, dataQuery.Id);
    }

    [Fact]
    public void ToDiscountQuery_Maps_ProductId()
    {
        var query = new ProductQuery { Id = 15 };

        var discountQuery = query.ToDiscountQuery();

        Assert.Equal(15, discountQuery.ProductId);
    }

    [Fact]
    public void ToResult_DoesNotMutate_Source()
    {
        var data = new ProductDataResult
        {
            Id = 1,
            Name = "Original",
            BasePrice = 10m
        };

        var _ = data.ToResult();

        // Source object should remain unchanged
        Assert.Equal(1, data.Id);
        Assert.Equal("Original", data.Name);
        Assert.Equal(10m, data.BasePrice);
    }
}
