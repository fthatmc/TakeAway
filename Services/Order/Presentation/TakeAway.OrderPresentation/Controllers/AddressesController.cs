using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Application.Features.CQRS.Commands.AddressCommands;
using TakeAway.Application.Features.CQRS.Handlers.AddressHandlers;
using TakeAway.Application.Features.CQRS.Queries.AddressQueries;

namespace TakeAway.OrderPresentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly GetAddressQueryHandler _getAddressQueryHandler;
		private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
		private readonly CreateAddressCommandHandler _createAddressCommandHandler;
		private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
		private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

		public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
		{
			_getAddressQueryHandler = getAddressQueryHandler;
			_getAddressByIdQueryHandler = getAddressByIdQueryHandler;
			_createAddressCommandHandler = createAddressCommandHandler;
			_updateAddressCommandHandler = updateAddressCommandHandler;
			_removeAddressCommandHandler = removeAddressCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AddressList()
		{
			var value = await _getAddressQueryHandler.Handle();
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
		{
			await _createAddressCommandHandler.Handle(command);
			return Ok("Adres eklendi");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAddress(int id)
		{
			await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
			return Ok("Adres silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
		{
			await _updateAddressCommandHandler.Handle(command);
			return Ok("Adres güncellendi");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAddress(int id)
		{
			var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
			return Ok(values);
		}
	}
}
