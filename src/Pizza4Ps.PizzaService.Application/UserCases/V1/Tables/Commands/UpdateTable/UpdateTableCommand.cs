using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.UpdateTable
{
    public class UpdateTableCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string Code{ get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public Guid ZoneId { get; set; }
    }
}
