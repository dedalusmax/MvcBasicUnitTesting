namespace WebApplication3.Test;

public class Calculator
{
    public double CalculateTax(double amount, double vatRate)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        return amount * vatRate / 100;
    }

    public double AddTax(double amount, double vatRate)
    {
        return amount + CalculateTax(amount, vatRate);
    }

    public double CalculateVat(double amount)
    {       
        return amount * 0.25; // Assuming a fixed VAT rate of 25%
    }
}
