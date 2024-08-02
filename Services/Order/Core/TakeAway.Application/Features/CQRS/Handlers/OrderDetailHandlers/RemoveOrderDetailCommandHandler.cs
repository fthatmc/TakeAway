using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Application.Features.CQRS.Commands.OrderDetailCommands;
using TakeAway.Application.Interfeces;
using TakeAway.Domain.Entities;

namespace TakeAway.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class RemoveOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;
		public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveOrderDetailCommand command)
		{
			await _repository.DeleteAsync(command.Id);
		}
	}
}
