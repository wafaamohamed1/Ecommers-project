namespace Ecommers.Domain.Entites.product
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductTypId { get; set; }
        public ProductType ProductType { get; set; } = null!;
        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; } = null!;
    }
}
