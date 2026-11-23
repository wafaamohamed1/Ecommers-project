namespace Ecommers.Domain.Entites.product
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
