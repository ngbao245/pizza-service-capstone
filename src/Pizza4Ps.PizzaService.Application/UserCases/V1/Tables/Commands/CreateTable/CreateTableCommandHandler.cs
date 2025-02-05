using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CreateTable
{
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ITableService _tableService;

        public CreateTableCommandHandler(IMapper mapper, ITableService tableService)
        {
            _mapper = mapper;
            _tableService = tableService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var result = await _tableService.CreateAsync(
                request.TableNumber,
                request.Capacity,
                request.Status,
                request.ZoneId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
