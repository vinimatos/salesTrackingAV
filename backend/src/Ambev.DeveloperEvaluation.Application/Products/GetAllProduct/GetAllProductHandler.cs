using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class GetAllProductHandler : IRequestHandler<GetAllProductCommand, GetAllProductCommandResult>
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
    public GetAllProductHandler(IProductRepository productRepository, IRatingRepository ratingRepository, IMapper mapper)
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
    public async Task<GetAllProductCommandResult> Handle(GetAllProductCommand command, CancellationToken cancellationToken)
    {

        var productList = await _productRepository.GetAllAsync(cancellationToken);

        return new GetAllProductCommandResult
        {
            Products = productList
        };
    }
}
