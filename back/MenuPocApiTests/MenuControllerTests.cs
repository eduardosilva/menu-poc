using MenuPocApi.Controllers;
using MenuPocApi.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MenuPocApiTests
{
	public class MenuControllerTests
	{
		public MenuController controller;

		public MenuControllerTests()
		{
			var logger = new Mock<ILogger<MenuController>>();
			var factory = new MenuFactory();
			controller = new MenuController(logger.Object, factory);
		}

		[Fact(DisplayName ="Get a valid time of day dishes")]
		public void Get_dishes_success()
		{

			Assert.Equal("eggs, Toast, coffee", controller.Post("morning, 1, 2, 3"));
		}

		[Fact(DisplayName = "Get a valid time of day dishes repeating only enabled dish")]
		public void Get_a_valid_repeated_dishes()
		{
			Assert.Equal("eggs, Toast, coffee, coffee", controller.Post("morning, 1, 2, 3, 3"));
		}

		[Fact(DisplayName = "Get a valid time of day dishes repeating only enabled dish")]
		public void Get_a_valid_non_repeated_not_enabled_dishes()
		{
			Assert.Equal("eggs, Toast, coffee", controller.Post("morning, 1, 1, 2, 3"));
		}

		[Fact(DisplayName = "Get a valid dishes with error when input has a invalid index")]
		public void Get_dishes_success_with_error_with_invalid_number()
		{
			Assert.Contains("error", controller.Post("morning, 1, 1, 2, 3, 7"));
		}

		[Fact(DisplayName = "Get a error with invalid input parts")]
		public void Get_error_with_input_with_invalid_parts()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => controller.Post("morning"));
		}

		[Fact(DisplayName = "Get a error with input without time of day")]
		public void Get_error_with_input_without_time_of_day()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => controller.Post("afternoon"));
		}

		[Fact(DisplayName = "Get a error with empty input")]
		public void Get_error_with_empty_input()
		{
			Assert.Throws<ArgumentNullException>(() => controller.Post(string.Empty));
		}
	}
}
