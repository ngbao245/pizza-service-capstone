using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        public Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
