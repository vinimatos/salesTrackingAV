using Ambev.DeveloperEvaluation.WebApi.Features.Order.Create;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer
{
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(user => user.CustomerId).NotNull();
            RuleFor(user => user.IsCancelled).NotNull();
        }
    }
}
