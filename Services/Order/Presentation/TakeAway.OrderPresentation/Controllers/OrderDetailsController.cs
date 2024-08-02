using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Application.Features.CQRS.Commands.OrderDetailCommands;
using TakeAway.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using TakeAway.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace TakeAway.OrderPresentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
		private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
		private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
		private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
		private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

		public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
		{
			_getOrderDetailQueryHandler = getOrderDetailQueryHandler;
			_getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
			_createOrderDetailCommandHandler = createOrderDetailCommandHandler;
			_updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
			_removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> OrderDetailList()
		{
			var value = await _getOrderDetailQueryHandler.Handle();
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
		{
			await _createOrderDetailCommandHandler.Handle(command);
			return Ok("Adres eklendi");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteOrderDetail(int id)
		{
			await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
			return Ok("Adres silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
		{
			await _updateOrderDetailCommandHandler.Handle(command);
			return Ok("Adres güncellendi");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrderDetail(int id)
		{
			var values = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
			return Ok(values);
		}
	}
}
