using Microsoft.AspNetCore.Builder.Extensions;
using Pizza4Ps.PizzaService.Application.Contract.Abstractions.Services;
using Pizza4Ps.PizzaService.Application.Contract.Abstractions.Services.IExternalServiceBase;
using Pizza4Ps.PizzaService.Application.Contract.DTOs;
using Pizza4Ps.PizzaService.Application.Contract.DTOs.BaseDto;
using Pizza4Ps.PizzaService.Infrastructure.Services.ExternalServiceBase;

namespace Pizza4Ps.PizzaService.Infrastructure.Services
{
    public class StaffService : ExternalService, IStaffService
    {
        private readonly ISendApiService _sendApiService;

        public StaffService(ISendApiService sendApiService)
        {
            _sendApiService = sendApiService;
        }
        public async Task<List<StaffDto>> GetListAsync()
        {
            //var parameters = new Dictionary<string, string>
            //        {
            //            { "maxResultCount", "100" }
            //        };
            var url = "http://vietsac.id.vn";
            var endpoint = "/staff-service/api/staffs";
            var resultApi = await _sendApiService
                .SendRequestAsync<BaseApiResponseDto<StaffDto>>(HttpMethod.Get, url, endpoint, null, null);
            if (resultApi != null)
            {
                return resultApi.Result.Items;
            }
            return null;
        }
    }
}
