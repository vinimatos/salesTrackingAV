using Ambev.DeveloperEvaluation.Application.Customer.Address;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDTO Address { get; set; }
    }
}
