
using TDD;

namespace TestProject_TDD
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.Calculate("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("123", 123)]
        [InlineData("42", 42)]
        public void StringWithNumberReturnsValue(String str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12,1", 13)]
        public void TwoNumbersSeparatedByCommaReturnsSum(String str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n1", 13)]
        public void TwoNumberSeparatedByNewLineReturnsSum(String str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2\n4", 7)]
        public void MultipleNumberSeparatedByNewLineOrCommaReturnsSum(String str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,1001\n4", 5)]
        [InlineData("1000", 1000)]
        [InlineData("1001", 0)]
        public void NumbersBiggerThanOneThousand(String str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-1,1001\n4", 5)]
        [InlineData("-1000", 1000)]
        [InlineData("-1001", 0)]
        public void NegativeNumbersReturnsException(String str, int expected)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.Calculate(str));
        }

        [Theory]
        [InlineData("//V1000", 1000)]
        public void AddingNewSeparators(String str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }
    }
}