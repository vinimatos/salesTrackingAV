using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.UpdateCustomer
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(user => user.Name).NotEmpty().Length(3, 50);
            RuleFor(user => user.Email).NotNull().Length(3, 50);
            RuleFor(user => user.PhoneNumber).NotEmpty().Length(3, 50);
        }
    }
}
