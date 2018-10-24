using PalindromeValidator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace PalindromeValidator.Core
{
	public class PalindromeValidatorService : IPalindromeValidatorService
	{
		private readonly ILogger<IPalindromeValidatorService> _logger;
		public PalindromeValidatorService(ILoggerFactory loggerFactory)
		{
			if (loggerFactory == null)
			{
				throw new ArgumentNullException(nameof(loggerFactory));
			}
			_logger = loggerFactory.CreateLogger<PalindromeValidatorService>();
		}

		public bool IsPositiveNumber(string input)
		{
			_logger.LogInformation(($"Started {nameof(IsPositiveNumber)} with input {input}"));

			int num = 0;
			bool checkParse = int.TryParse(input, out num);

			_logger.LogInformation(($"Ended {nameof(IsPositiveNumber)}"));
			return (num >= 0 && checkParse);
		}

		public bool IsPalindrom(string input)
		{
			_logger.LogInformation(($"Started {nameof(IsPalindrom)} with input {input}"));

			int num, temp, remainder, reverse = 0;

			int.TryParse(input, out num);

			temp = num;

			while (num > 0)
			{

				remainder = num % 10;
				reverse = reverse * 10 + remainder;
				num /= 10;
			}

			_logger.LogInformation(($"Ended {nameof(IsPalindrom)}"));
			return (temp == reverse);
		}
	}
}
