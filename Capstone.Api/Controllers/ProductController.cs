using Capstone.Application.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Api.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetProduct()
    {
        var response = await _productService.GetProduct();

        return Ok(response);
    }
}