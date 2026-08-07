namespace Ex2DelegateAndMethodAssignments;

class Program
{
    static void Main(string[] args)
    {
        Operation op1 = Addition;
        Operation op2 = Subtraction;

        Console.WriteLine(PerformOperation(op1, 4, 5));
        Console.WriteLine(PerformOperation(op2, 4, 5));

    }

    delegate int Operation(int x, int y);

    static int Addition(int x, int y)
    {
        return x + y;
    }
    static int Subtraction(int x, int y)
    {
        return x - y;
    }

    static int PerformOperation(Operation operation, int x, int y)
    {
        return operation(x, y);
    }

}
