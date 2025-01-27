using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository productRepository, IRatingRepository ratingRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _ratingRepository = ratingRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productRepository.GetByIdAsync(command.Id, cancellationToken);

        product.Rating.Rate = command.Ratings.Rate;
        product.Rating.Count = command.Ratings.Count;
        product.Title = command.Title;
        product.Price = command.Price;
        product.Description = command.Description;
        var rating = await _ratingRepository.UpdateAsync(product.Rating, cancellationToken);

        product.Rating = rating;

         await _productRepository.UpdateAsync(product, cancellationToken);

        return new UpdateProductCommandResult
        {
            Data = DateTime.UtcNow,
        };
    }
}
