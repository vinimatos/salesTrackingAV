using Ambev.DeveloperEvaluation.Application.Report;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer
{
    public class ReportHandler : IRequestHandler<ReportCommand, List<ReportCommandResult>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ReportHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<ReportCommandResult>> Handle(ReportCommand command, CancellationToken cancellationToken)
        {
            var result = await _itemRepository.ReportAsync(command.CustomerName, command.IsCancelled, command.DateSale);

            var reportList = new List<ReportCommandResult>();
            foreach (var item in result)
            {
                var report = new ReportCommandResult
                {
                    OrderItems = item.OrderItems,
                    Product = item.Product,
                    Quantity = item.Quantity
                };
                reportList.Add(report);
            }
            return reportList;
        }
    }
}
