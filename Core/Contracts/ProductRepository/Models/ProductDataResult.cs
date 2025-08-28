namespace Core.Contracts.ProductRepository.Models;

public class ProductDataResult
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal BasePrice { get; set; }
}
