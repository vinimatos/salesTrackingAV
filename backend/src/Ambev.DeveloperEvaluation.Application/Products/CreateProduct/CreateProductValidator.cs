using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateUser;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(user => user.Title).NotEmpty().Length(3, 50);
        RuleFor(user => user.Price).NotNull().GreaterThan(0);
        RuleFor(user => user.Description).NotEmpty().Length(3, 50);
        RuleFor(user => user.Category).NotEmpty().Length(3, 50);
        RuleFor(user => user.Ratings.Rate).NotEmpty();
    }
}