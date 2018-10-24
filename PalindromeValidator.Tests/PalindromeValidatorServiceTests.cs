using PalindromeValidator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace PalindromeValidator.Tests
{
	public class PalindromeValidatorServiceTests
	{
		private readonly PalindromeValidatorService _sut;
		private readonly Mock<ILoggerFactory> _loggerFactory;
		private readonly string _zero = "0";

		public PalindromeValidatorServiceTests()
		{
			_loggerFactory = new Mock<ILoggerFactory>();
			_sut = new PalindromeValidatorService(_loggerFactory.Object);
		}

		[Theory]
		[InlineData("-234")]
		[InlineData("-1221")]
		[InlineData("-56")]
		public void IsPositiveNumber_For_Negative_Number_Should_Return_False(string negativeNumber)
		{
			_sut.IsPositiveNumber(negativeNumber).Should().BeFalse();
		}


		[Theory]
		[InlineData("234")]
		[InlineData("1221")]
		[InlineData("56")]
		public void IsPositiveNumber_For_Positive_Number_Should_Return_True(string positiveNumber)
		{
			_sut.IsPositiveNumber(positiveNumber).Should().BeTrue();
		}

		[Fact]
		public void IsPositiveNumber_For_Zero_Should_Return_True()
		{
			_sut.IsPositiveNumber(_zero).Should().BeTrue();
		}


		[Theory]
		[InlineData("1234")]
		[InlineData("12212")]
		[InlineData("563345")]
		public void IsPalindrom_For_Non_Palindrom_Number_Should_Return_False(string nonPalindrom)
		{
			_sut.IsPalindrom(nonPalindrom).Should().BeFalse();
		}

		[Theory]
		[InlineData("12221")]
		[InlineData("4567654")]
		[InlineData("3356533")]
		public void IsPalindrom_For_Palindrom_Number_Should_Return_True(string palindromNumber)
		{
			_sut.IsPalindrom(palindromNumber).Should().BeTrue();
		}
	}
}
