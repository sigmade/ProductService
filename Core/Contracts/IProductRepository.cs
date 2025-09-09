using Core.Models;

namespace Core.Contracts;

public interface IProductRepository
{
    Task<Product> GetById(int id);
}
