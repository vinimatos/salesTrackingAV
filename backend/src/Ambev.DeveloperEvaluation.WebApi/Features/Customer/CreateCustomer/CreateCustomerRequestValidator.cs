using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(user => user.Name).NotEmpty().Length(3, 50);
            RuleFor(user => user.Email).NotNull().Length(3, 50);
            RuleFor(user => user.PhoneNumber).NotEmpty().Length(3, 50);
            RuleFor(user => user.Address).NotNull();
        }
    }
}
