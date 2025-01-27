using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Order.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(user => user.CustomerId).NotNull();
        RuleFor(user => user.OrderItems).NotNull();
    }
}