using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class VoucherService : DomainService, IVoucherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderVoucherRepository _orderVoucherRepository;
        private readonly IAdditionalFeeRepository _additionalFeeRepository;

        public VoucherService(IUnitOfWork unitOfWork, IVoucherRepository voucherRepository, IOrderRepository orderRepository, IOrderVoucherRepository orderVoucherRepository, IAdditionalFeeRepository additionalFeeRepository)
        {
            _unitOfWork = unitOfWork;
            _voucherRepository = voucherRepository;
            _orderRepository = orderRepository;
            _orderVoucherRepository = orderVoucherRepository;
            _additionalFeeRepository = additionalFeeRepository;
        }

        public async Task<Guid> CreateAsync(string code, DiscountTypeEnum discountType, DateTime expiryDate, Guid voucherTypeId)
        {
            throw new NotImplementedException();
            //var entity = new Voucher(Guid.NewGuid(), code, discountType, expiryDate, voucherTypeId);
            //_voucherRepository.Add(entity);
            //await _unitOfWork.SaveChangeAsync();
            //return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _voucherRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _voucherRepository.HardDelete(entity);
                }
                else
                {
                    _voucherRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _voucherRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _voucherRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string code, DiscountTypeEnum discountType, DateTime expiryDate, Guid voucherTypeId)
        {
            throw new NotImplementedException();
            //var entity = await _voucherRepository.GetSingleByIdAsync(id);
            //entity.UpdateVoucher(code, discountType, expiryDate, voucherTypeId);
            //await _unitOfWork.SaveChangeAsync();
            //return entity.Id;
        }

        public async Task<bool> UserVoucherAsync(Guid orderId, string code)
        {
            var existingOrder = await _orderRepository.GetSingleByIdAsync(orderId);
            if (existingOrder == null)
            {
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            }
            if (existingOrder.Status != OrderStatusEnum.Unpaid)
            {
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_INVALID_STATUS);
            }

            var existingVoucher = await _voucherRepository.GetSingleAsync(x => x.Code == code, "VoucherBatch");
            if (existingVoucher == null)
            {
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_NOT_FOUND);
            }

            if (!existingVoucher.IsClaimed)
            {
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_NOT_ACTIVATED);
            }

            if (existingVoucher.VoucherBatch != null)
            {
                var now = DateTime.UtcNow;
                if (now < existingVoucher.VoucherBatch.StartDate || now > existingVoucher.VoucherBatch.EndDate)
                {
                    throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_EXPIRED);
                }

                // Check for duplicate voucher from the same batch on this order.
                var duplicateVoucherExists = await _orderVoucherRepository
                    .GetListAsTracking(ov => ov.OrderId == orderId, "Voucher")
                    .AnyAsync(ov => ov.Voucher.VoucherBatchId == existingVoucher.VoucherBatchId);
                if (duplicateVoucherExists)
                {
                    throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.DUPLICATE_VOUCHER_FROM_BATCH);
                }
            }

            decimal orderSubtotal = existingOrder.OrderItems.Sum(item => item.TotalPrice);

            decimal discountValue = 0;
            if (existingVoucher.DiscountType == DiscountTypeEnum.Direct)
            {
                discountValue = existingVoucher.DiscountValue;
            }
            else if (existingVoucher.DiscountType == DiscountTypeEnum.Percentage)
            {
                discountValue = Math.Round(orderSubtotal * existingVoucher.DiscountValue / 100, 2);
            }
            else
            {
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.INVALID_DISCOUNT_TYPE);
            }

            var discountFee = new AdditionalFee(
                Guid.NewGuid(),
                $"Voucher: {existingVoucher.Code}",
                $"Applied voucher {existingVoucher.Code}",
                -discountValue,
                existingOrder.Id
            );
            _additionalFeeRepository.Add(discountFee);

            existingOrder.AdditionalFees.Add(discountFee);

            var orderVoucher = new OrderVoucher(Guid.NewGuid(), existingOrder.Id, existingVoucher.Id);
            _orderVoucherRepository.Add(orderVoucher);

            decimal newTotal = orderSubtotal + existingOrder.AdditionalFees.Sum(fee => fee.Value);
            existingOrder.SetTotalPrice(newTotal);
            _orderRepository.Update(existingOrder);
            _unitOfWork.SaveChangeAsync();
            return true;
        }


    }
}
