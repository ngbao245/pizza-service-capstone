using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

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
            TableStatusEnum? tableStatus = string.IsNullOrEmpty(request.Status)
                ? throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS)
                : Enum.TryParse(request.Status, true, out TableStatusEnum status)
                    ? status
                    : throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS);

            var result = await _tableService.CreateAsync(
                request.TableNumber,
                request.Capacity,
                tableStatus.Value,
                request.ZoneId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
