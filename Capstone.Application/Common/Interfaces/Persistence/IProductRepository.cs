using Capstone.Domain.Entities;

namespace Capstone.Application.Common.Interfaces.Persistence;

public interface IProductRepository
{
    Task<Product[]> GetProducts();
}