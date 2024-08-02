using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Application.Features.Mediator.Commands.OrderingCommands;
using TakeAway.Application.Interfeces;
using TakeAway.Domain.Entities;

namespace TakeAway.Application.Features.Mediator.Handlers.OrderingHandlers
{
	public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
	{
		private readonly IRepository<Ordering> _repository;
		public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
		{
			await _repository.DeleteAsync(request.Id);
		}
	}
}
