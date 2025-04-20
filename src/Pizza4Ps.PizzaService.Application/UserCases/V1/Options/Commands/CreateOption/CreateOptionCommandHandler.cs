using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.CreateOption
{
	public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, ResultDto<Guid>>
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptionRepository _optionRepository;
        private readonly IOptionItemRepository _optionItemRepository;
        private readonly IMapper _mapper;
		private readonly IOptionService _optionService;

		public CreateOptionCommandHandler(IMapper mapper, IOptionService optionService,
			IOptionItemRepository optionItemRepository,
			IOptionRepository optionRepository,
			IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
            _optionRepository = optionRepository;
            _optionItemRepository = optionItemRepository;
            _mapper = mapper;
			_optionService = optionService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
		{
            var entity = new Option(Guid.NewGuid(), request.Name, request.Description, request.SelectMany);
            _optionRepository.Add(entity);
			foreach (var item in request.OptionItems)
			{
				var optionItem = new OptionItem(
					id: Guid.NewGuid(),
					name: item.Name,
					additionalPrice: item.AdditionalPrice,
					optionId: entity.Id);
				_optionItemRepository.Add(optionItem);
			}
            await _unitOfWork.SaveChangeAsync();
            return new ResultDto<Guid>
            {
				Id = entity.Id
            };
		}
	}
}
