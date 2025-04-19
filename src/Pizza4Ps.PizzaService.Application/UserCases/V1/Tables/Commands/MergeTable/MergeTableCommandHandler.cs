using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.MergeTable
{
    public class MergeTableCommandHandler : IRequestHandler<MergeTableCommand>
    {
        private readonly ITableMergeRepository _tableMergeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITableRepository _tableRepository;

        public MergeTableCommandHandler(ITableRepository tableRepository,
            IUnitOfWork unitOfWork, ITableMergeRepository tableMergeRepository)
        {
            _tableMergeRepository = tableMergeRepository;
            _unitOfWork = unitOfWork;
            _tableRepository = tableRepository;
        }
        public async Task Handle(MergeTableCommand request, CancellationToken cancellationToken)
        {
            var tables = await _tableRepository.GetListAsTracking(x => request.TableIds.Contains(x.Id)).ToListAsync();
            if (!tables.Any())
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }
            if (tables.Any(t => t.TableMergeId != null))
                throw new BusinessException("Một hoặc nhiều bàn đang được ghép nhóm khác!");
            if (tables.Any(t => t.CurrentOrderId != null))
                throw new BusinessException("Bàn đã được sử dụng cho một đơn hàng khác, vui lòng kiểm tra lại");


            var mergedGroup = new TableMerge
            {
                Id = Guid.NewGuid(),
                Name = request.GroupName,
            };
            foreach (var table in tables)
            {
                table.SetMergeTable(mergedGroup.Id,
                    mergedGroup.Name);
                table.SetOpening();
                _tableRepository.Update(table);
            }
            _tableMergeRepository.Add(mergedGroup);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
