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
	public class CreateOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;
		public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateOrderDetailCommand command)
		{
			await _repository.CreateAsync(new OrderDetail
			{
				Amount = command.Amount,
				OrderingId = command.OrderingId,
				Price = command.Price,
				ProductName = command.ProductName,
				ProdutcId = command.ProdutcId,
				TotalPrice = command.TotalPrice
			});
		}

	}
}
