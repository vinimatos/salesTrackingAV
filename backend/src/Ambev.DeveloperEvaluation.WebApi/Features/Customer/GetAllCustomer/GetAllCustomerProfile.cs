using Ambev.DeveloperEvaluation.Application.Customer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class GetAllCustomerProfile : Profile
    {
        public GetAllCustomerProfile()
        {
            CreateMap<GetAllCustomerCommandResult, GetAllCustomerResponse>();
        }
    }
}
