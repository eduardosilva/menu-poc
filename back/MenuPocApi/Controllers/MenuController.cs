using MenuPocApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MenuPocApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MenuController : ControllerBase
	{
		private readonly ILogger<MenuController> _logger;
		private readonly IMenuFactory _menuFactory;

		public MenuController(ILogger<MenuController> logger, IMenuFactory menuFactory)
		{
			_logger = logger;
			_menuFactory = menuFactory;
		}

		/// <summary>
		/// Get a menu based in your selected time of day and quantities
		/// </summary>
		/// <param name="input">input</param>  
		/// <remarks>
		/// Example: 
		///		input: morning, 1, 2, 3
		///		output: eggs, toast, coffee
		/// </remarks>
		[HttpPost]
		[Route("dishes")]
		public string Post([FromBody] string input)
		{
			using (_logger.BeginScope("Getting dishes"))
			{
				_logger.LogInformation("Input parameter: {input}", input);

				if (string.IsNullOrWhiteSpace(input))
					throw new ArgumentNullException(nameof(input));

				var inputParts = input.Split(',');
				if (!(inputParts.Count() > 2))
					throw new ArgumentOutOfRangeException(nameof(input));

				var timeOfDayPart = inputParts[0];
				if (!Enum.TryParse(timeOfDayPart, ignoreCase: true, out TimeOfDay timeOfDay)) {
					throw new ArgumentOutOfRangeException(timeOfDayPart);
				}

				var menu = _menuFactory.GetMenu(timeOfDay);

				Func<string, bool> isValidQuantity = (p) => int.TryParse(p, out int result);
				var dishIndexes = inputParts.Skip(1)
											.Where(isValidQuantity)
											.Select(int.Parse);

				var selectedDishes = menu.GetMenuOptions(dishIndexes);
				var outPut = string.Join(", ", selectedDishes);

				_logger.LogInformation("Output: {output}", outPut);

				return outPut;
			}

		}
	}
}
