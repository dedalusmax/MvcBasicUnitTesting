using System.Collections;
using WebApplication3.Test;

namespace WebApplication3.TestProject;

public class CalculatorTests
{
    public CalculatorTests()
    {
        Console.WriteLine("CalculatorTests instance created");  
    }

    [Fact]
    public void CalculateTax_ShouldReturnCorrectTaxAmount()
    {
        // Arrange
        var calculator = new Calculator();
        double amount = 100;
        double vatRate = 30;

        // Act
        double tax = calculator.CalculateTax(amount, vatRate);

        // Assert
        Assert.Equal(30, tax);
        Assert.IsType<double>(tax);
        Assert.NotEqual(0, tax);
        Assert.True(tax > 0);
    }

    [Fact]
    public void AddTax_ShouldReturnAmountWithTax()
    {
        // Arrange
        var calculator = new Calculator();
        double amount = 100;
        double vatRate = 30;

        // Act
        double totalAmount = calculator.AddTax(amount, vatRate);

        // Assert
        Assert.Equal(130, totalAmount);
        Assert.IsType<double>(totalAmount);
        Assert.NotEqual(0, totalAmount);
        Assert.True(totalAmount > amount);
    }

    [Fact]
    public void CalculateTax_ShouldHandleZeroAmount()
    {
        // Arrange
        var calculator = new Calculator();
        double amount = 0;
        double vatRate = 30;

        // Act
        double tax = calculator.CalculateTax(amount, vatRate);

        // Assert
        Assert.Equal(0, tax);
    }

    [Fact]
    public void CalculateTax_ShouldHandleNegativeAmount()
    {
        // Arrange
        var calculator = new Calculator();
        double amount = -100;
        double vatRate = 30;

        // Act
        //double tax = calculator.CalculateTax(amount, vatRate);
        Action result = () => calculator.CalculateTax(amount, vatRate);

        // Assert
        Assert.Throws<ArgumentException>(result);
    }

    [Theory]
    [InlineData(100, 30, 30)]
    [InlineData(200, 15, 30)]
    [InlineData(50, 20, 10)]
    [InlineData(0, 25, 0)]
    //[InlineData(-50, 25, -5)]
    public void CalculateTax_ShouldReturnCorrectTaxAmount_ForVariousInputs(double amount, double vatRate, double expectedTax)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        double tax = calculator.CalculateTax(amount, vatRate);

        // Assert
        Assert.Equal(expectedTax, tax);
    }

    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void CalculateTax_ShouldReturnCorrectTaxAmount_ForClassData(double amount, double vatRate, double expectedTax)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        double tax = calculator.CalculateTax(amount, vatRate);

        // Assert
        Assert.Equal(expectedTax, tax);
    }

    [Theory]
    [MemberData(nameof(GetData))]
    public void CalculateTax_ShouldReturnCorrectTaxAmount_ForMemberData(double amount, double vatRate, double expectedTax)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        double tax = calculator.CalculateTax(amount, vatRate);

        // Assert
        Assert.Equal(expectedTax, tax);
    }

    public static IEnumerable<object[]> GetData()
    {
        return
        [
            [100, 30, 30],
            [200, 15, 30],
            [50, 20, 10],
            [0, 25, 0]
        ];
    }

    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100, 30, 30 };
            yield return new object[] { 200, 15, 30 };
            yield return new object[] { 50, 20, 10 };
            yield return new object[] { 0, 25, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
