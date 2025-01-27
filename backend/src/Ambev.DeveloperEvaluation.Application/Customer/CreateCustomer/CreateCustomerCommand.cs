using Ambev.DeveloperEvaluation.Application.Customer.Address;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResult>
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDTO Address { get; set; }
    }
}
