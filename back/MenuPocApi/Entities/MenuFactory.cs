using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuPocApi.Entities
{
	public class MenuFactory : IMenuFactory
	{
		private static IEnumerable<Menu> menus;
		public MenuFactory()
		{

			if (menus != null) return;

			var menuBaseType = typeof(Menu);
			var assembly = menuBaseType.Assembly;
			menus = assembly.GetTypes().Where(t => t.BaseType == menuBaseType && !t.IsAbstract)
											.Select(t => assembly.CreateInstance(t.FullName))
											.Cast<Menu>()
											.ToArray();
		}

		public Menu GetMenu(TimeOfDay timeOfDay) => menus.FirstOrDefault(t => t.TimeOfDay == timeOfDay);
	}

	public interface IMenuFactory
	{
		Menu GetMenu(TimeOfDay timeOfDay);
	}
}
