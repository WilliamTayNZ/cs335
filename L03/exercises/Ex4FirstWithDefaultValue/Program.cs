namespace Ex4FirstWithDefaultValue;

class Program
{
    static void Main(string[] args)
    {
        int[] integers = { 1, 3, 16, 181, 5, 7, 8, 9, 10, 11 };

        int element = integers.FirstOrDefault(i => i > 20 && i % 2 == 0);
        // should return 0 as default?

        if (element == 0)
        {
            Console.WriteLine("No even number greater than 20 is found. Default value (0) returned");
        } else
        {
            Console.WriteLine($"First even number greater than 20: {element}"); 
        }

    }


}
