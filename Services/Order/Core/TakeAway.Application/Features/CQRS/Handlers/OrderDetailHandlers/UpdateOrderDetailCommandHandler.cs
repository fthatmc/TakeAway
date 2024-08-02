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
	public class UpdateOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;
		public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateOrderDetailCommand command)
		{
			var values = await _repository.GetByIdAsync(command.OrderDetailId);
			values.OrderingId = command.OrderDetailId;
			values.ProductName = command.ProductName;
			values.Amount = command.Amount;
			values.Price = command.Price;
			values.TotalPrice = command.TotalPrice;
			values.ProdutcId = command.ProdutcId;
			await _repository.UpdateAsync(values);
		}
	}
}
