using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Application.Features.CQRS.Queries.AddressQueries;
using TakeAway.Application.Features.CQRS.Results.AddressResults;
using TakeAway.Application.Interfeces;
using TakeAway.Domain.Entities;

namespace TakeAway.Application.Features.CQRS.Handlers.AddressHandlers
{
	public class GetAddressByIdQueryHandler
	{
		private readonly IRepository<Address> _repository;
		public GetAddressByIdQueryHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}
		public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetAddressByIdQueryResult
			{
				AddressId = values.AddressId,
				City = values.City,
				Detail = values.Detail,
				District = values.District,
				Email = values.Email,
				Name = values.Name,
				Surname = values.Surname,
				UserId = values.UserId
			};
		}
	}
}
