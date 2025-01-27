using Ambev.DeveloperEvaluation.Application.Customer.Address;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<UpdateCustomerCommandResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDTO Address { get; set; }
    }
}
