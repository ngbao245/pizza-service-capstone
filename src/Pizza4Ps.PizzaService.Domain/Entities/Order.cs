using Microsoft.EntityFrameworkCore.Diagnostics;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Order : EntityAuditBase<Guid>
    {
        public virtual ICollection<OrderItem> Items { get; set; }
        public Guid PaymentTypeId { get; set; }
        public Guid FeedbackId { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual FeedBack FeedBack { get; set; }

        private Order() { }

        public Order(Guid id , Guid paymentTypeId, Guid feedbackId)
        {
            Id = id;
            PaymentTypeId = paymentTypeId;
            FeedbackId = feedbackId;
        }
    }
}
