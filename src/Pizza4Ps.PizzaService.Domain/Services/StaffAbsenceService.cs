using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class StaffAbsenceService : DomainService, IStaffAbsenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffAbsenceRepository _staffAbsenceRepository;

        public StaffAbsenceService(IUnitOfWork unitOfWork, IStaffAbsenceRepository staffAbsenceRepository)
        {
            _unitOfWork = unitOfWork;
            _staffAbsenceRepository = staffAbsenceRepository;
        }

        public async Task<Guid> CreateAsync(Guid staffId, Guid workingSlotId, DateOnly absentDate)
        {
            var existed = await _staffAbsenceRepository
                .GetSingleAsync(x => x.StaffId == staffId
                && x.WorkingSlotId == workingSlotId
                && x.AbsentDate == absentDate);
            if (existed != null) throw new BusinessException(BussinessErrorConstants.StaffAbsenceErrorConstant.STAFF_ABSENCE_EXISTED);

            var entity = new StaffAbsence(Guid.NewGuid(), staffId, workingSlotId, absentDate);
            _staffAbsenceRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _staffAbsenceRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _staffAbsenceRepository.HardDelete(entity);
                }
                else
                {
                    _staffAbsenceRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _staffAbsenceRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _staffAbsenceRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
