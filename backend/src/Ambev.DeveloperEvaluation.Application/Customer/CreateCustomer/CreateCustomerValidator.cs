using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(user => user.Name).NotEmpty().Length(3, 50);
            RuleFor(user => user.Email).NotNull().Length(3, 50);
            RuleFor(user => user.PhoneNumber).NotEmpty().Length(3, 50);
            RuleFor(user => user.Address).NotNull();
        }
    }
}
