using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Application.Features.Mediator.Commands.OrderingCommands;
using TakeAway.Application.Features.Mediator.Queries.OrderingQueries;

namespace TakeAway.OrderPresentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderingsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public OrderingsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> OrderingList()
		{
			var value = await _mediator.Send(new GetOrderingQuery());
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş Eklendi");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrdering(int id)
		{
			var values = await _mediator.Send(new GetOrderingByIdQuery(id));
			return Ok(values);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteOrdering(int id)
		{
			await _mediator.Send(new RemoveOrderingCommand(id));
			return Ok("Sipariş Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş Güncellendi");
		}
	}
}
