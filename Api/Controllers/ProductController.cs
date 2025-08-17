using Api.Models;
using Core.UseCases.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IGetProductUseCase getProductUseCase) : ControllerBase
{
    private readonly IGetProductUseCase _getProductUseCase = getProductUseCase;

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetProduct(int id)
    {
        var productCoreResult = await _getProductUseCase.Execute(id);
        var productResponse = productCoreResult.ToResponse();

        return Ok(productResponse);
    }
}
