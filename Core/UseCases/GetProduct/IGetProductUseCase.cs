using Core.Models;

namespace Core.UseCases.GetProduct;

public interface IGetProductUseCase
{
    Task<ProductCoreResult> Execute(int id);
}
