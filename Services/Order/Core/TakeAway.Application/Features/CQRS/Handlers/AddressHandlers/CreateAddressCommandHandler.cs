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
	public class CreateAddressCommandHandler
	{
		private readonly IRepository<Address> _repository;
		public CreateAddressCommandHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateAddressCommand command)
		{
			await _repository.CreateAsync(new Address
			{
				City = command.City,
				Detail = command.Detail,
				District = command.District,
				Email = command.Email,
				Name = command.Name,
				Surname = command.Surname,
				UserId = command.UserId
			});
		}
	}
}
