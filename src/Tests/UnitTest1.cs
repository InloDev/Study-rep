using Test8ClassLibrary;

namespace Tests;

public static class ConvertTests
{
    public sealed class StringToIntTests
    {
        [Theory]
        [InlineData("123", 123)]
        [InlineData("001", 1)]
        public void Convert_ValidString_ReturnsCorrectNumbers(string input, int expected)
        {
            var converter = new StringToIntConverter();
            var result = converter.Convert(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_InvalidString_ThrowsFormatException_1()
        {
            var converter = new StringToIntConverter();

            Assert.Throws<FormatException>(() => converter.Convert("abc"));
        }

        [Fact]
        public void Convert_InvalidString_ThrowsFormatException_2()
        {
            var converter = new StringToIntConverter();

            Assert.Throws<FormatException>(() => converter.Convert(null));
        }

        [Fact]
        public void Convert_InvalidString_ThrowsFormatException_3()
        {
            var converter = new StringToIntConverter();

            Assert.Throws<FormatException>(() => converter.Convert("2147483650"));
        }
    }


    public sealed class StringToBoolConverterTests
    {
        [Theory]
        [InlineData("true", true)]
        [InlineData("True", true)]
        [InlineData("TRUE", true)]
        [InlineData("false", false)]
        [InlineData("False", false)]
        [InlineData("FALSE", false)]
        public void Convert_ValidString_ReturnsCorrectBool(string input, bool expected)
        {
            var converter = new StringToBoolConverter();

            var result = converter.Convert(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_InvalidString_ThrowsFormatException()
        {
            var converter = new StringToBoolConverter();

            Assert.Throws<FormatException>(() => converter.Convert("maybe"));
        }
    }
}