namespace Ex1Delegate;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4 };
        D1 d1 = M1;
        d1("donkey", numbers);

        List<string> fruits = new List<string> { "Apple", "Banana", "Orange", "Watermelon" };

        D2 d2 = M2;
        IEnumerable<string> displayedFruits = d2(3, true, fruits);

        foreach (string fruitDescription in displayedFruits)
        {
            Console.WriteLine(fruitDescription);
        }
    }

    delegate void D1(string x, List<int> y);

    public static void M1(string x, List<int> y)
    {
        foreach (int i in y)
        {
            Console.WriteLine("{0} {1},", x, i);
        }
    }

    delegate IEnumerable<string> D2(int a, bool b, List<string> c);

    public static IEnumerable<string> M2(int numberOfFruits, bool randomBoolean, List<string> fruits)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < numberOfFruits; i++)
        {
            result.Add($"a = {numberOfFruits}, b = {randomBoolean}, string = {fruits[i]}");
        }

        return result;

    }
    

}
