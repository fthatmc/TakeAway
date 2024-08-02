using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Application.Features.CQRS.Results.OrderDetailResults;
using TakeAway.Application.Interfeces;
using TakeAway.Domain.Entities;

namespace TakeAway.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailQueryHandler
	{
		private readonly IRepository<OrderDetail> _repository;
		public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetOrderDetailQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetOrderDetailQueryResult
			{
				OrderDetailId = x.OrderDetailId,
				Amount = x.Amount,
				OrderingId = x.OrderingId,
				Price = x.Price,
				ProductName = x.ProductName,
				ProdutcId = x.ProdutcId,
				TotalPrice = x.TotalPrice
			}).ToList();
		}
	}
}
