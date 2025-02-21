//using AutoMapper;
//using MediatR;
//using Pizza4Ps.PizzaService.Application.DTOs;
//using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
//using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
//using Pizza4Ps.PizzaService.Domain.Enums;

//namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetTableStatus
//{
//    public class GetTableStatusQueryHandler : IRequestHandler<GetTableStatusQuery, bool>
//    {
//        private readonly IMapper _mapper;
//        private readonly ITableRepository _tableRepository;
//        private readonly ITableService _tableService;

//        public GetTableStatusQueryHandler(IMapper mapper, ITableRepository tableRepository, ITableService tableService)
//        {
//            _mapper = mapper;
//            _tableRepository = tableRepository;
//            _tableService = tableService;
//        }

//        public async Task<bool> Handle(GetTableStatusQuery request, CancellationToken cancellationToken)
//        {
//            var entity = await _tableRepository.GetSingleByIdAsync(request.Id);
//            if (entity.Status == TableStatusEnum.Closing)
//            {
//                await _tableService.UpdateAsync(
//                    entity.Id,
//                    entity.Code,
//                    entity.Capacity,
//                    TableStatusEnum.Opening,
//                    entity.ZoneId
//                );
//                return true;
//            }
//            return false;
//        }
//    }
//}
