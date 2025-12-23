namespace Capstone.Application.Services.Product;

public record ProductResult(
    string Id,
    string Name,
    string ClothType,
    string Color,
    string? ImageUrl,
    DateTime CreatedAt,
    decimal? ImportPrice,
    decimal? SalePrice,
    Guid CreatedBy,
    Guid? ConfirmedBy
);