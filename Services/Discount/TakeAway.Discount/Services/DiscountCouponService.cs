using Dapper;
using TakeAway.Discount.Context;
using TakeAway.Discount.Dtos;

namespace TakeAway.Discount.Services
{
	public class DiscountCouponService : IDiscountCouponService
	{
		private readonly DiscountContext _context;
		public DiscountCouponService(DiscountContext context)
		{
			_context = context;
		}
		public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
		{
			string query = "insert into Coupons (Code,Rate,IsActive) values (@code,@rate,@isActive)";
			var parameters = new DynamicParameters();
			parameters.Add("@code", createDiscountCouponDto.Code);
			parameters.Add("@rate", createDiscountCouponDto.Rate);
			parameters.Add("@isActive", createDiscountCouponDto.IsActive);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}

		public async Task DeleteDiscountCouponAsync(int id)
		{
			string query = "delete from Coupons where CouponId=@coupondId";
			var parameters = new DynamicParameters();
			parameters.Add("@coupondId", id);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}

		public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
		{
			string query = "Select * From Coupons Where couponId=@couponId";
			var parameters = new DynamicParameters();
			parameters.Add("@couponId", id);
			var connection = _context.CreateConnection();
			var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
			return value;
		}

		public async Task<List<ResultDiscountCouponDto>> ResultDiscountCouponAsync()
		{
			string query = "Select * From Coupons";
			var connection = _context.CreateConnection();
			var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
			return values.ToList();
		}

		public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
		{
			string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive Where CouponId=@couponId";
			var parameters = new DynamicParameters();
			parameters.Add("@rate", updateDiscountCouponDto.Rate);
			parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
			parameters.Add("@code", updateDiscountCouponDto.Code);
			parameters.Add("@couponId", updateDiscountCouponDto.CouponId);
			var connection = _context.CreateConnection();
			await connection.ExecuteAsync(query, parameters);
		}
	}
}
