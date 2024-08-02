using AutoMapper;
using TakeAway.Catalog.Dtos.CategoryDtos;
using TakeAway.Catalog.Dtos.DailyDiscountDtos;
using TakeAway.Catalog.Dtos.ProductDtos;
using TakeAway.Catalog.Dtos.SliderDtos;
using TakeAway.Catalog.Entities;

namespace TakeAway.Catalog.Mapping
{
	public class GeneralMapping : Profile
	{
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

			CreateMap<Product, ResultProductDto>().ReverseMap();
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, GetByIdProductDto>().ReverseMap();

			CreateMap<Slider, ResultSliderDto>().ReverseMap();
			CreateMap<Slider, CreateSliderDto>().ReverseMap();
			CreateMap<Slider, UpdateSliderDto>().ReverseMap();
			CreateMap<Slider, GetByIdSliderDto>().ReverseMap();

			CreateMap<DailyDiscount, ResultDailyDiscountDto>().ReverseMap();
			CreateMap<DailyDiscount, CreateDailyDiscountDto>().ReverseMap();
			CreateMap<DailyDiscount, UpdateDailyDiscountDto>().ReverseMap();
			CreateMap<DailyDiscount, GetByIdDailyDiscountDto>().ReverseMap();
		}
    }
}
