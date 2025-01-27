using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer
{
    public class GetAllCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public GetAllCustomerRequestValidator()
        {
        }
    }
}
