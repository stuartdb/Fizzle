using Fizzle.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FizzleTest.Models
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void NumberShouldHaveDefaultInitialValue_WhenCreated()
        {
            // Arrange
            var number = new Number();
            // Act
            // Assert
            number.Initial.Should().Be(1);
        }

        [TestMethod]
        public void NumberShouldHaveNoTransform_WhenCreated()
        {
            // Arrange
            var number = new Number();
            // Act
            // Assert
            number.Transform.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void NumberShouldHaveNoTransform_WhenInitialZero()
        {
            // Arrange
            var number = new Number { Initial = 0 };
            // Act
            number.Fizzle();
            // Assert
            number.Transform.Should().BeNullOrEmpty();
        }

        [DataTestMethod]
        [DataRow(3)]
        [DataRow(6)]
        [DataRow(9)]
        [DataRow(-9999)]
        public void NumberShouldHaveTransform_WhenInitialMultipleOfThree(int value)
        {
            // Arrange
            var number = new Number { Initial = value };
            // Act
            number.Fizzle();
            // Assert
            number.Transform.Should().Be("Fizz");
        }

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]        
        [DataRow(20)]        
        [DataRow(-1000)]
        public void NumberShouldHaveTransform_WhenInitialMultipleOfFive(int value)
        {
            // Arrange
            var number = new Number { Initial = value };
            // Act
            number.Fizzle();
            // Assert
            number.Transform.Should().Be("Buzz");
        }

        [DataTestMethod]
        [DataRow(15)]
        [DataRow(30)]
        [DataRow(60)]
        [DataRow(-60)]
        public void NumberShouldHaveTransform_WhenInitialMultipleOfThreeAndFive(int value)
        {
            // Arrange
            var number = new Number { Initial = value };
            // Act
            number.Fizzle();
            // Assert
            number.Transform.Should().Be("FizzBuzz");
        }
    }
}
