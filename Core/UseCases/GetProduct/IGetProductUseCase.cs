using Core.Models;

namespace Core.UseCases.GetProduct;

public interface IGetProductUseCase
{
    Task<Product> Execute(int id);
}
