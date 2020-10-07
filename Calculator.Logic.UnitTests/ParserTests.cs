﻿using System;
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
        [TestCase("1 + 1", "1 1 +")]
        public void ConvertToRPN_ValidInput(string input, int expected)
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
    }
}
