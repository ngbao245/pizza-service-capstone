﻿using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetVoucherById
{
    public class GetVoucherByIdQueryHandler : IRequestHandler<GetVoucherByIdQuery, VoucherDto>
	{
		private readonly IMapper _mapper;
		private readonly IVoucherRepository _voucherRepository;

		public GetVoucherByIdQueryHandler(IMapper mapper, IVoucherRepository voucherRepository)
		{
			_mapper = mapper;
			_voucherRepository = voucherRepository;
		}

		public async Task<VoucherDto> Handle(GetVoucherByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _voucherRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<VoucherDto>(entity);
			return result;
		}
	}
}
