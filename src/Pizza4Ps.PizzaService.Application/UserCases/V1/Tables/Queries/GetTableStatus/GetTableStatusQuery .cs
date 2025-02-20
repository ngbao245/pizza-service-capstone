using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetTableStatus
{
    public class GetTableStatusQuery : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
