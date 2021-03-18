using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MenuPocApi.Entities
{
	public class MorningMenu : Menu
	{
		public override TimeOfDay TimeOfDay => TimeOfDay.Morning;

		public override IEnumerable<string> Dishes => new[] { "eggs", "Toast", "coffee" };

		public override int DishIndexEnabledToRepeat => 3;
	}
}
