using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(user => user.Title).NotEmpty().Length(3, 50);
        RuleFor(user => user.Price).NotNull().GreaterThan(0);
        RuleFor(user => user.Description).NotEmpty().Length(3, 50);
        RuleFor(user => user.Category).NotEmpty().Length(3, 50);
        RuleFor(user => user.Ratings.Rate).NotEmpty();
    }
}