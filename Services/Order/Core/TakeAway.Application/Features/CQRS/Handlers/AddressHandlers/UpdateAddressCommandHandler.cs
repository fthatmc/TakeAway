using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Application.Features.CQRS.Commands.AddressCommands;
using TakeAway.Application.Interfeces;
using TakeAway.Domain.Entities;

namespace TakeAway.Application.Features.CQRS.Handlers.AddressHandlers
{
	public class UpdateAddressCommandHandler
	{
		private readonly IRepository<Address> _repository;
		public UpdateAddressCommandHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateAddressCommand command)
		{
			var values = await _repository.GetByIdAsync(command.AddressId);
			values.Surname = command.Surname;
			values.UserId = command.UserId;
			values.Email = command.Email;
			values.City = command.City;
			values.District = command.District;
			values.Name = command.Name;
			values.Detail = command.Detail;
			await _repository.UpdateAsync(values);
		}
	}
}
