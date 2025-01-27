using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Rating : BaseEntity
    {
        public double Rate { get; set; }
        public int Count { get; set; }
    }
}
