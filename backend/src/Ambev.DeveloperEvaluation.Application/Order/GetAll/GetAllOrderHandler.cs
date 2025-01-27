using Ambev.DeveloperEvaluation.Application.Dashboard;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderCommand, GetAllOrderCommandResult>
    {
       
        private readonly IItemRepository _itemRepository;
        public GetAllOrderHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<GetAllOrderCommandResult> Handle(GetAllOrderCommand command, CancellationToken cancellationToken)
        {
          var itemList = await _itemRepository.GetOrders();

            return new GetAllOrderCommandResult
            {
                Items = itemList
            };
        }
    }
}
