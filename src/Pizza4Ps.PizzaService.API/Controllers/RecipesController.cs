using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.CreateRecipe;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Queries.GetListRecipe;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Queries.GetRecipeById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public RecipesController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        /// <summary>
        /// Tạo món ăn
        /// </summary>
        /// <remarks>
        ///Milligram,
        ///Gram,
        ///Kilogram,
        ///Milliliter,
        ///Liter,
        ///Piece,
        ///Teaspoon,
        ///Tablespoon
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRecipeCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListRecipeQuery query)
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
        public async Task<IActionResult> GetByCustomerCodeAsync([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetRecipeByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
