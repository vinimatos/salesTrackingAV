using Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class CreateCustomerRequestProfile : Profile
    {

        public CreateCustomerRequestProfile()
        {

            CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
        }
    }
}
