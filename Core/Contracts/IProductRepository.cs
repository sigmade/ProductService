namespace Core.Contracts;

public interface IProductRepository
{
    Task<ProductDataResult> GetByIdAsync(int id);
}
