namespace CalculatorLibrary;

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public float Divide(float a, float b)
    {
        if (a == 0 && b == 0)
            return 0;

        if (a != 0 && b == 0)
            throw new DivideByZeroException();

        return a / b;
    }
}
