using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Report
{
    public class ReportCommand : IRequest<List<ReportCommandResult>>
    {
        public string? CustomerName { get; set; }
        public DateTime? DateSale { get; set; }
        public bool? IsCancelled { get; set; }
    }
}
