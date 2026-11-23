using AutoMapper;
using Ecommers.Apliction.DTOs.Product;
using Ecommers.Domain.Entites.product;

namespace Ecommers.Apliction.profiles
{
    internal sealed class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductBrand, ProductBrandDto>();
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
