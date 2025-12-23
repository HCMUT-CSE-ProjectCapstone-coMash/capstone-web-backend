namespace Capstone.Domain.Entities;

public class Product {
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ClothType { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string? ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public decimal? ImportPrice { get; set; }
    public decimal? SalePrice { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ConfirmedBy { get; set; }
};