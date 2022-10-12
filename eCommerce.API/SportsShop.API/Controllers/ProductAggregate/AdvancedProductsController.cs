using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportsShop.Application.Quries.ProductAggregate.Advanced;
using System.Threading.Tasks;

namespace SportsShop.API.Controllers.ProductAggregate
{
    public class AdvancedProductsController : BaseController
    {
        private readonly IMediator _mediator;
        public AdvancedProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(nameof(GetSortedProducts))]
        public async Task<IActionResult> GetSortedProducts([FromQuery]GetSortedProductsQuery input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpGet(nameof(GetFilteredProducts))]
        public async Task<IActionResult> GetFilteredProducts([FromQuery] GetFilteredProductQuery input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpGet(nameof(GetSearchedProducts))]
        public async Task<IActionResult> GetSearchedProducts([FromQuery] GetSearchedPorudctQuery input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpGet(nameof(GetPaginatedProducts))]
        public async Task<IActionResult> GetPaginatedProducts([FromQuery] GetProductsPaginatedQuery input)
        {
            return Ok(await _mediator.Send(input));
        }
    }
}
