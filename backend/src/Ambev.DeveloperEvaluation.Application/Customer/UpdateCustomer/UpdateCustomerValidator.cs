using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customer.UpdateCustomer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(user => user.Name).NotEmpty().Length(3, 50);
            RuleFor(user => user.Email).NotNull().Length(3, 50);
            RuleFor(user => user.PhoneNumber).NotEmpty().Length(3, 50);
        }
    }
}
