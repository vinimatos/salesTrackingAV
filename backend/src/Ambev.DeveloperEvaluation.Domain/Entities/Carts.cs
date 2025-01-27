using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Carts : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public Customers Customer { get; set; }
        public bool IsCancelled { get; set; }
    }
}
