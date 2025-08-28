using Core.Models;

namespace Core.Contracts.ProductRepository.Models;

public class ProductDataResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
