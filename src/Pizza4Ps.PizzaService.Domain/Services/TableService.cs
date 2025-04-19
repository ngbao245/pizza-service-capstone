using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class TableService : DomainService, ITableService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITableRepository _tableRepository;

        public TableService(IUnitOfWork unitOfWork, ITableRepository tableRepository)
        {
            _unitOfWork = unitOfWork;
            _tableRepository = tableRepository;
        }

        public async Task<Guid> CreateAsync(string code, int capacity, Guid zoneId)
        {
            var existedTable = await _tableRepository.GetSingleAsync(x => x.Code == code);  
            if (existedTable != null)
            {
                throw new BusinessException("Mã code bàn đã tồn tại");
            }
            var entity = new Table(Guid.NewGuid(), code, capacity, zoneId);
            _tableRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _tableRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _tableRepository.HardDelete(entity);
                }
                else
                {
                    _tableRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _tableRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _tableRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }
        public async Task<Guid> CloseTable(Guid tableId)
        {
            var entity = await _tableRepository.GetSingleByIdAsync(tableId);
            if (entity.CurrentOrderId != null)
            {
                throw new BusinessException("Vui lòng xử lý đơn hàng ngay tại bàn này trước khi đóng bàn");
            }
            entity.SetClosing();
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }


        public async Task<Guid> OpenTable(Guid tableId)
        {
            var entity = await _tableRepository.GetSingleByIdAsync(tableId);
            entity.SetOpening();
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task<Guid> LockTable(Guid tableId, string? note)
        {
            var entity = await _tableRepository.GetSingleByIdAsync(tableId);
            if (entity.CurrentOrderId != null)
            {
                throw new BusinessException("Vui lòng xử lý đơn hàng ngay tại bàn này trước khi khoá bàn");
            }
            entity.SetLocked(note);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task<Guid> UpdateAsync(Guid id, string code, int capacity, Guid zoneId)
        {
            var entity = await _tableRepository.GetSingleByIdAsync(id);

            if (entity == null)
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);

            entity.UpdateTable(code, capacity, zoneId);

            await _unitOfWork.SaveChangeAsync();

            return entity.Id;
        }

    }
}
