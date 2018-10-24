using System;
using System.Collections.Generic;
using System.Text;

namespace PalindromeValidator.Abstractions
{
	public interface IPalindromeValidatorService
	{
		bool IsPositiveNumber(string input);
		bool IsPalindrom(string input);
	}
}
