using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuPocApi.Entities
{
	public class NightMenu : Menu
	{
		public override TimeOfDay TimeOfDay => TimeOfDay.Night;

		public override IEnumerable<string> Dishes => new[] { "steak", "potato", "wine", "cake" };

		public override int DishIndexEnabledToRepeat => 2;
	}
}
