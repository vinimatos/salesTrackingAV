using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Customer
{
    public class GetAllDashboardCommandResult
    {
        public int Customers { get; set; }
        public int Products { get; set; }
        public int Orders { get; set; }

    }
}
