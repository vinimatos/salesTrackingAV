using Ambev.DeveloperEvaluation.Application.Products.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly IMapper _mapper;


    /// <summary>
    /// Initializes a new instance of CreateUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateUserCommand</param>
    public CreateProductHandler(IProductRepository productRepository, IRatingRepository ratingRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _ratingRepository = ratingRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateUserCommand request
    /// </summary>
    /// <param name="command">The CreateUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    public async Task<CreateProductCommandResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var rating = _mapper.Map<Domain.Entities.Rating>(command.Ratings);
        var createdRating = await _ratingRepository.CreateAsync(rating, cancellationToken);

        var product = _mapper.Map<Domain.Entities.Product>(command);

        product.Rating = createdRating;
        
        var createdProduct = await _productRepository.CreateAsync(product, cancellationToken);
        var result = _mapper.Map<CreateProductCommandResult>(createdProduct);
        return result;
    }
}
