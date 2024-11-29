using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class FeedBack : EntityAuditBase<Guid>
    {
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }

        public FeedBack()
        {
        }

        public FeedBack(int rating, string comments, Guid orderId)
        {
            Rating = rating;
            Comments = comments;
            OrderId = orderId;
        }
    }
}
