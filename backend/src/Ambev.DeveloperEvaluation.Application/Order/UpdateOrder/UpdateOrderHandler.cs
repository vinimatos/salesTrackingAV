using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Order.CreateOrder;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResult>
{

    private readonly ICartRepository _cartRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public UpdateOrderHandler(ICartRepository cartRepository, IOrderItemRepository orderItemRepository, IItemRepository itemRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _orderItemRepository = orderItemRepository;
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<UpdateOrderCommandResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateOrderValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
      var item = await _itemRepository.GetByIdAsync(command.Id);

        var cart = await _cartRepository.GetCartsById(item.OrderItems.Cart.Id);

        cart.IsCancelled = command.IsCancelled;

        await _cartRepository.Update(cart);

        return new UpdateOrderCommandResult
        {
            Data = DateTime.UtcNow
        };
    }
}
