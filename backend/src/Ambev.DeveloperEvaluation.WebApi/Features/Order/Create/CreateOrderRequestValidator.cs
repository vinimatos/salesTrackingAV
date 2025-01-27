using Ambev.DeveloperEvaluation.WebApi.Features.Order.Create;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(user => user.CustomerId).NotNull();
            RuleFor(user => user.OrderItems).NotNull();
        }
    }
}
