namespace Ambev.DeveloperEvaluation.WebApi.Features.Report
{
    public class ReportRequest
    {
        public string? CustomerName { get; set; }
        public DateTime? DateSale { get; set; }
        public bool? IsCancelled { get; set; }
    }
}
