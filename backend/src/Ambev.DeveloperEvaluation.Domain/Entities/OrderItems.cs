using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class OrderItems : BaseEntity
    {
        public Carts Cart { get; set; }
        public decimal Discount { get; set; }
    }
}
