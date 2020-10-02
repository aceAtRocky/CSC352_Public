using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Calculator.Logic.UnitTests
{
    [TestFixture]
    public class ParserTests
    {
        [TestCase("1+1", 2)]
        public void Parse_ValidInput(string input, int expected)
        {
            // Arrange
            // Taken care of in the arguments

            // Act
            int actual = Parser.Parse(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
