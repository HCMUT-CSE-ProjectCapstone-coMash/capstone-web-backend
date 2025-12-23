using Capstone.Application.Common.Interfaces.Persistence;
using Capstone.Application.Common.Result;

namespace Capstone.Application.Services.Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductResult[]>> GetProducts()
    {
        var products = await _productRepository.GetProducts();

        var result = products.Select(p => new ProductResult(
            p.Id.ToString(),
            p.Name,
            p.ClothType,
            p.Color,
            p.ImageUrl,
            p.CreatedAt,
            p.ImportPrice,
            p.SalePrice,
            p.CreatedBy,
            p.ConfirmedBy
        )).ToArray();

        return Result<ProductResult[]>.Success(result);
    }
}