using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuPocApi.Entities
{
	public enum TimeOfDay
	{
		Morning,
		Night
	}

	public abstract class Menu
	{
		public abstract TimeOfDay TimeOfDay { get; }
		public abstract IEnumerable<string> Dishes { get; }

		public abstract int DishIndexEnabledToRepeat { get; }

		public IEnumerable<string> GetMenuOptions(IEnumerable<int> dishIndexes)
		{
			var aggregatedIndexes = dishIndexes.Aggregate(new List<int>(), (aggregation, dishIndex) =>
			{
				if (dishIndex != DishIndexEnabledToRepeat && aggregation.Contains(dishIndex))
					return aggregation;

				aggregation.Add(dishIndex);
				return aggregation;
			});

			var result = aggregatedIndexes.SelectMany(validIndex => Dishes.Where((d, dishIndex) => (dishIndex + 1) == validIndex).DefaultIfEmpty("error"));
			return result;
		}
	}
}
