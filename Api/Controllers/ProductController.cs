using Api.Models;
using Core.UseCases.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// API controller providing endpoints to retrieve product information.
/// </summary>
/// <param name="getProductUseCase">Use case that encapsulates product retrieval and discount application logic.</param>
[ApiController]
[Route("api/[controller]")]
public class ProductController(IGetProductUseCase getProductUseCase) : ControllerBase
{
    private readonly IGetProductUseCase _getProductUseCase = getProductUseCase;

    /// <summary>
    /// Retrieves a single product by its identifier.
    /// </summary>
    /// <param name="id">Unique identifier of the product.</param>
    /// <returns>HTTP 200 with the <see cref="ProductResponse"/> payload when found.</returns>
    /// <response code="200">Returns the product.</response>
    /// <response code="404">If the product does not exist (behavior depends on underlying use case / repository).</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetProduct(int id)
    {
        var productCoreResult = await _getProductUseCase.Execute(new() { Id = id });
        var productResponse = productCoreResult.ToResponse();

        return Ok(productResponse);
    }
}
