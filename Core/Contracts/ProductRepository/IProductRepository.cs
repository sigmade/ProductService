using Core.Contracts.ProductRepository.Models;

namespace Core.Contracts.ProductRepository;

public interface IProductRepository
{
    Task<ProductDataResult> GetByIdAsync(int id);
}
