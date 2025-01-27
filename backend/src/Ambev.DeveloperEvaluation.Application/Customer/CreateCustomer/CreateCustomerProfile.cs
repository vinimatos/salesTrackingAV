using Ambev.DeveloperEvaluation.Application.Customer.Address;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer
{
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerCommand, Customers>();
            CreateMap<Customers, CreateCustomerCommandResult>();
            CreateMap<AddressDTO, Domain.Entities.Address>();
        }
    }
}
