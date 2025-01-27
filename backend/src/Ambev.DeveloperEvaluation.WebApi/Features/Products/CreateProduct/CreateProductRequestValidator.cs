using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(user => user.Title).NotEmpty().Length(3, 50);
            RuleFor(user => user.Price).NotNull().GreaterThan(0);
            RuleFor(user => user.Description).NotEmpty().Length(3, 50);
            RuleFor(user => user.Category).NotEmpty().Length(3, 50);
            RuleFor(user => user.Ratings.Rate).NotEmpty();
        }
    }
}
