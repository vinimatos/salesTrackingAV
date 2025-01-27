using Ambev.DeveloperEvaluation.Application.Customer.Address;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customer.UpdateCustomer
{
    public class UpdateCustomerProfile : Profile
    {
        public UpdateCustomerProfile()
        {
            CreateMap<UpdateCustomerCommand, Customers>();
            CreateMap<Customers, UpdateCustomerCommandResult>();
            CreateMap<AddressDTO, Domain.Entities.Address>();
        }
    }
}
