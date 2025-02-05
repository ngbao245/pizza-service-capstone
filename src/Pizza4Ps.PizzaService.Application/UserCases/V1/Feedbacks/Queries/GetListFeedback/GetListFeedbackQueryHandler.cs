using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedback
{
    public class GetListFeedbackQueryHandler : IRequestHandler<GetListFeedbackQuery, PaginatedResultDto<FeedbackDto>>
	{
		private readonly IMapper _mapper;
		private readonly IFeedbackRepository _feedbackRepository;

		public GetListFeedbackQueryHandler(IMapper mapper, IFeedbackRepository feedbackRepository)
		{
			_mapper = mapper;
			_feedbackRepository = feedbackRepository;
		}

		public async Task<PaginatedResultDto<FeedbackDto>> Handle(GetListFeedbackQuery request, CancellationToken cancellationToken)
		{
			var query = _feedbackRepository.GetListAsNoTracking(
				x => (request.Rating == null || x.Rating == request.Rating)
				&& (request.Comments == null || x.Comments.Contains(request.Comments))
				&& (request.OrderId == null || x.OrderId == request.OrderId),
				includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.FeedbackErrorConstant.FEEDBACK_NOT_FOUND);
			var result = _mapper.Map<List<FeedbackDto>>(entities);
			var totalCount = await query.CountAsync();
            return new PaginatedResultDto<FeedbackDto>(result, totalCount);

        }
    }
}
