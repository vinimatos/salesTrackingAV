using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Order.CreateOrder;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderValidator()
    {
        RuleFor(user => user.Id).NotNull();
    }
}