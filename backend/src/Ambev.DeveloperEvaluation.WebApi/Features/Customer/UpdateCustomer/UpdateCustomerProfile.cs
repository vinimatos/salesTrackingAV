
using Ambev.DeveloperEvaluation.Application.Customer.UpdateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.UpdateCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateCustomer
{
    public class UpdateCustomerProfile : Profile
    {
        public UpdateCustomerProfile()
        {
            CreateMap<UpdateCustomerRequest, UpdateCustomerCommand>();
            CreateMap<UpdateCustomerCommandResult, UpdateCustomerResponse>();
        }
    }
}
