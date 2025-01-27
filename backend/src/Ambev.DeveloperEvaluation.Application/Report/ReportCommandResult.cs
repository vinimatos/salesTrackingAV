using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Report
{
    public class ReportCommandResult
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public OrderItems OrderItems { get; set; }

    }
}
