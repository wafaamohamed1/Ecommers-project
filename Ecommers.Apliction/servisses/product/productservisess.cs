using AutoMapper;
using Ecommers.Apliction.DTOs.Product;
using Ecommers.Apliction.Iservises.product;
using Ecommers.Domain.Entites.product;
using Ecommers.Domain.commov;
using Ecommers.Domain.commov.contractic;

namespace Ecommers.Apliction.servisses.product;

public sealed class ProductServices(IUnitOfWork unitOfWork, IMapper mapper) : IProductserves
{
    private readonly IGenericRepository<Product> _products = unitOfWork.GetRepository<Product>();

    public async Task<IReadOnlyList<ProductDto>> GetAllProductAsync(CancellationToken cancellationToken = default)
    {
        var products = await _products.GetAllAsync(cancellationToken);
        return mapper.Map<IReadOnlyList<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await _products.GetByIdAsync(id, cancellationToken);
        return product is null ? null : mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto productDto, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(productDto);
        var product = mapper.Map<Product>(productDto);
        await _products.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto?> UpdateProductAsync(int id, ProductDto productDto, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(productDto);
        var product = await _products.GetByIdAsync(id, cancellationToken);
        if (product is null)
        {
            return null;
        }

        mapper.Map(productDto, product);
        _products.Update(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<ProductDto>(product);
    }

    public async Task<bool> DeleteProductAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await _products.GetByIdAsync(id, cancellationToken);
        if (product is null)
        {
            return false;
        }

        _products.Delete(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
