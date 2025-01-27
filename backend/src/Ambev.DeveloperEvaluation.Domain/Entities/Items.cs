using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Items : BaseEntity
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public OrderItems OrderItems { get; set; }
    }
}
