using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            var calculator = new Calculator();
            double a = 5;
            double b = 3;

            // Act
            double result = calculator.Add(a, b);

            // Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            // Arrange
            var calculator = new Calculator();
            double a = 10;
            double b = 4;

            // Act
            double result = calculator.Subtract(a, b);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            // Arrange
            var calculator = new Calculator();
            double a = 6;
            double b = 7;

            // Act
            double result = calculator.Multiply(a, b);

            // Assert
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            // Arrange
            var calculator = new Calculator();
            double a = 20;
            double b = 5;

            // Act
            double result = calculator.Divide(a, b);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            var calculator = new Calculator();
            double a = 20;
            double b = 0;

            // Act
            calculator.Divide(a, b);

            // Assert is handled by the ExpectedException attribute
        }
    }
}