using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsShop.API.Constants;
using SportsShop.Application.Command.ProductAggregate;
using SportsShop.Application.Command.ProductAggregate.ProductImages;
using SportsShop.Application.Filters;
using SportsShop.Application.Quries.ProductAggregate;
using System.Threading.Tasks;

namespace SportsShop.API.Controllers.ProductAggregate
{
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = UserType.AdminUser)]
        [HttpGet(nameof(GetProductById))]
        public async Task<IActionResult> GetProductById([FromQuery]GetProductByIdQuery input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.AdminUser)]

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _mediator.Send(new GetProducsQuery()));
        }

        [Authorize(Roles = UserType.AdminUser)]
        [HttpGet(nameof(GetPaginatedProducts))]
        public async Task<IActionResult> GetPaginatedProducts([FromQuery] GetProductsPaginatedQuery input)
        {
            return Ok(await _mediator.Send(input));
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public async Task<IActionResult> UploadProduct([FromQuery] UploadProductCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.Admin)]

        [HttpPost(nameof(UploadProductImage))]
        public async Task<IActionResult> UploadProductImage([FromQuery]UploadImageCommand input)
        {
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (ImageNotUploadedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = UserType.Admin)]

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.Admin)]

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand input)
        {
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (ImageNotDeletedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = UserType.Admin)]

        [HttpDelete(nameof(DeleteProductImage))]
        public async Task<IActionResult> DeleteProductImage(DeleteProductCommand input)
        {
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (ImageNotDeletedException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
