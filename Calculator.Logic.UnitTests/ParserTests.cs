using NUnit.Framework;

namespace Calculator.Logic.UnitTests
{
    [TestFixture]
    public class ParserTests
    {
        [TestCase("1 + 1", "1 1 +")]
        [TestCase("1 + 2 * 3 ^ 4", "1 2 3 4 ^ * +")]
        [TestCase("( 2 + 2 ) ^ 2", "2 2 + 2 ^")]
        [TestCase("3 + 2 - 1", "3 2 + 1 -")]
        [TestCase("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3", "3 4 2 * 1 5 - 2 3 ^ ^ / +")]
        [TestCase("1 + 2 + 3", "1 2 + 3 +")]
        [TestCase("1 + sqrt ( 4 )", "1 4 sqrt +")]
        [TestCase("1 + sqrt ( 2 ^ 2 )", "1 2 2 ^ sqrt +")]
        [TestCase("1 + sqrt ( sqrt ( 2 ^ 2 ) )", "1 2 2 ^ sqrt sqrt +")]
        [TestCase("1 + sqrt ( sqrt ( ( 2 ^ 2 + 2 ) ) )", "1 2 2 ^ 2 + sqrt sqrt +")]
        public void ConvertToRPN_ValidInput(string input, string expected)
        {
            // Arrange
            // Taken care of in the arguments

            // Act
            string actual = Parser.ConvertToRPN(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("+", "+", true)]
        [TestCase("-", "-", true)]
        [TestCase("*", "*", true)]
        [TestCase("/", "/", true)]
        [TestCase("^", "^", true)]
        [TestCase("+", "-", true)]
        [TestCase("-", "+", true)]
        [TestCase("+", "*", false)]
        [TestCase("+", "/", false)]
        [TestCase("+", "^", false)]
        [TestCase("-", "*", false)]
        [TestCase("-", "/", false)]
        [TestCase("-", "^", false)]
        public void OperatorHasEqualPrecidence_ValidInput(string op1, string op2, bool expected)
        {
            bool actual = Parser.OperatorHasEqualPrecidence(op1, op2);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("1 1 +", "1 + 1")]
        [TestCase("3 1 + 2 *", "( 3 + 1 ) * 2")]
        public void ConvertToInfix_ValidInput(string rpn, string expected)
        {
            string actual = Parser.ConvertToInfix(rpn);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
