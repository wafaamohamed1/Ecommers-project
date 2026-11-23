using Ecommers.Apliction.DTOs.Product;

namespace Ecommers.Apliction.Iservises.product
{
    public interface IProductserves
    {
        Task<IReadOnlyList<ProductDto>> GetAllProductAsync(CancellationToken cancellationToken = default);
        Task<ProductDto?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ProductDto> CreateProductAsync(ProductDto productDto, CancellationToken cancellationToken = default);

        Task<ProductDto?> UpdateProductAsync(int id, ProductDto productDto, CancellationToken cancellationToken = default);
        Task<bool> DeleteProductAsync(int id, CancellationToken cancellationToken = default);

    }
}
