using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PalindromeValidator.Abstractions;
using PalindromeValidator.Core;

namespace PalindromeValidator
{
	class Program
	{
		static void Main(string[] args)
		{
			//setup DI
			var serviceProvider = new ServiceCollection()
				.AddLogging()
				.AddSingleton<IPalindromeValidatorService, PalindromeValidatorService>()
				.BuildServiceProvider();

			//configure console logging
			serviceProvider
				.GetService<ILoggerFactory>();

			var logger = serviceProvider.GetService<ILoggerFactory>()
				.CreateLogger<Program>();
			logger.LogInformation("Starting Palindrome Validator");

			Console.WriteLine("Enter a positive number \n");
			var input = Console.ReadLine();
			var validator = serviceProvider.GetService<IPalindromeValidatorService>();

			if (validator.IsPositiveNumber(input))
			{
				if (validator.IsPalindrom(input))
					Console.WriteLine("Number is a palindrome \n");
				else
					Console.WriteLine("Number is not a palindrome \n");
			}
			else
			{
				Console.WriteLine("Wrong entry !!");
			}

			Console.ReadLine();

			logger.LogInformation("Finished Palindrome Validator");
		}
	}
}
