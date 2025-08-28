using Core.UseCases.GetProduct.Models;

namespace Core.UseCases.GetProduct;

public interface IGetProductUseCase
{
    Task<ProductCoreResult> Execute(int id);
}
