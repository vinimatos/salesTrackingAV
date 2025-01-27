using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Order.CreateOrder;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IItemRepository _itemRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public CreateOrderHandler
        (IProductRepository productRepository,
        IItemRepository itemRepository,
        ICustomerRepository customerRepository,
        ICartRepository cartRepository,
        IOrderItemRepository orderItemRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _itemRepository = itemRepository;
        _customerRepository = customerRepository;
        _cartRepository = cartRepository;
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateOrderValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = await _customerRepository.GetByIdAsync(command.CustomerId, cancellationToken);
        if (customer == null)
            throw new ValidationException("Customer not found");

        decimal discount = 0;
        foreach (var item in command.OrderItems)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
            if (product == null)
                throw new ValidationException("Product not found");

            if (item.Quantity > 21)
                throw new Exception("The maximum quantity allowed for a single item in a sale is 20. Please adjust the quantity to proceed.");

            if (item.Quantity > 4 && item.Quantity < 10)
                discount = 0.1m;
            else if (item.Quantity > 9 && item.Quantity < 21)
                discount = 0.2m;

            var newCart = new Carts
            {
                CreateDate = DateTime.UtcNow,
                Customer = customer,
                IsCancelled = false,
            };

            var carts = await _cartRepository.CreateAsync(newCart);
            var orderItem = await _orderItemRepository.CreateAsync(new OrderItems
            {
                Cart = carts,
                Discount = discount
            });
            await _itemRepository.CreateAsync(new Items
            {
                Product = product,
                Quantity = item.Quantity,
                OrderItems = orderItem
            });
        }


        return new CreateOrderCommandResult
        {
            Data = DateTime.UtcNow,
        };
    }
}
