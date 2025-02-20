using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetAllProductsProfile : Profile
    {
        public GetAllProductsProfile()
        {            
            CreateMap<Product, GetProductResult>();
        }
    }
}
