using Ecommers.Apliction.DTOs.Product;
using Ecommers.Apliction.Iservises.product;
using Microsoft.AspNetCore.Mvc;

namespace Ecommers.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProductsController(IProductserves productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll(CancellationToken cancellationToken)
    {
        var products = await productService.GetAllProductAsync(cancellationToken);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductByIdAsync(id, cancellationToken);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(ProductDto productDto, CancellationToken cancellationToken)
    {
        var product = await productService.CreateProductAsync(productDto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProductDto>> Update(int id, ProductDto productDto, CancellationToken cancellationToken)
    {
        var product = await productService.UpdateProductAsync(id, productDto, cancellationToken);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await productService.DeleteProductAsync(id, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
