using Capstone.Application.Common.Result;

namespace Capstone.Application.Services.Product;

public interface IProductService
{
    Task<Result<ProductResult[]>> GetProducts();
} 