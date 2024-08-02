﻿namespace TakeAway.Catalog.Settings
{
	public interface IDatabaseSettings
	{
		public string CategoryCollectionName { get; set; }
		public string SliderCollectionName { get; set; }
		public string ProductCollectionName { get; set; }
		public string DailyDiscountCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
