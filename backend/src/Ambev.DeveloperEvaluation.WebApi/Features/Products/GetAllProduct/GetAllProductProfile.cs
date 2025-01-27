using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class GetAllProductProfile : Profile
    {
        public GetAllProductProfile()
        {

            CreateMap<GetAllProductCommandResult, GetAllProductResponse>();

        }
    }
}
