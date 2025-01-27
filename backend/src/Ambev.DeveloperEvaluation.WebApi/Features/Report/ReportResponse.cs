using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Report
{
    public class ReportResponse
    {
        public List<Items> Items { get; set; }
        public decimal Total { get; set; }

    }
}
