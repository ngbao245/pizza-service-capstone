using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedbackIgnoreQueryFilter
{
    public class GetListFeedbackIgnoreQueryFilterQueryHandler : IRequestHandler<GetListFeedbackIgnoreQueryFilterQuery, PaginatedResultDto<FeedbackDto>>
	{
		private readonly IMapper _mapper;
		private readonly IFeedbackRepository _feedbackRepository;

		public GetListFeedbackIgnoreQueryFilterQueryHandler(IMapper mapper, IFeedbackRepository feedbackRepository)
		{
			_mapper = mapper;
			_feedbackRepository = feedbackRepository;
		}

		public async Task<PaginatedResultDto<FeedbackDto>> Handle(GetListFeedbackIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _feedbackRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.Rating == null || x.Rating == request.Rating)
					&& (request.Comments == null || x.Comments.Contains(request.Comments))
					&& (request.OrderId == null || x.OrderId == request.OrderId)
					&& x.IsDeleted == request.IsDeleted);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			var result = _mapper.Map<List<FeedbackDto>>(entities);
			var totalCount = await query.CountAsync();
            return new PaginatedResultDto<FeedbackDto>(result, totalCount);
        }
    }
}
