using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CloseTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CreateTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.DeleteTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.LockTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.OpenTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.RestoreTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.UpdateTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTableIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetTableById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public TablesController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        /// <summary>
        /// Thêm danh sách trạng thái thiết bị.
        /// </summary>
        /// <remarks>
        /// Opening
        /// Closing
        /// Locked
        /// Paid
        /// Booked
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTableCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        //[HttpPost("{id}/check-in")]
        //public async Task<IActionResult> CheckInTableByIdAsync([FromRoute] Guid id)
        //{
        //    var result = await _sender.Send(new GetTableStatusQuery { Id = id });
        //    return Ok(new ApiResponse
        //    {
        //        Result = result,
        //        Message = Message.GET_SUCCESS,
        //        StatusCode = StatusCodes.Status200OK
        //    });
        //}

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListTableIgnoreQueryFilterQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListTableQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetTableByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateTableCommand request)
        {
            request.Id = id;
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreTableCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteTableCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("close-table/{tableId}")]
        public async Task<IActionResult> CloseTableAsync(Guid tableId)
        {
            await _sender.Send(new CloseTableCommand
            {
                Id = tableId
            });
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpPut("open-table/{tableId}")]
        public async Task<IActionResult> OpenTableAsync(Guid tableId)
        {
            await _sender.Send(new OpenTableCommand
            {
                Id = tableId
            });
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpPut("lock-table/{tableId}")]
        public async Task<IActionResult> LockTableAsync([FromRoute] Guid tableId, [FromBody] LockTableCommand lockTable)
        {
            lockTable.Id = tableId;
            await _sender.Send(lockTable);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
