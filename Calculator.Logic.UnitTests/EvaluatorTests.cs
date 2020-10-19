namespace Calculator.Logic.UnitTests
{

    using NUnit.Framework;

    [TestFixture]
    public class EvaluatorTests
    {
        [TestCase("1 + 1", 2.0)]
        [TestCase("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3", 3.0001220703125)]
        public void EvaluateInfix_ValidInput(string input, double expected)
        {
            double actual = Evaluate.EvaluateInfix(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("1 1 +", 2.0)]
        [TestCase("3 4 2 * 1 5 - 2 3 ^ ^ / +", 3.0001220703125)]
        [TestCase("3 3 3 + +", 9)]
        public void EvaluateRPN_ValidInput(string input, double expected)
        {
            double actual = Evaluate.EvaluateRPN(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("3 3 3 + ^", "")]
        public void EvaluateRPN_StepByStepInfix_ValidInput(string input, string expected)
        {
            string actual = Evaluate.EvaluateRPN_StepByStepInfix(input);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
