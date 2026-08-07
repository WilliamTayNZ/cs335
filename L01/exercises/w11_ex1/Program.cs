namespace w11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate mobile phones
            MobilePhone phone1 = new MobilePhone
            {
                Brand = "Apple",
                Model = "iPhone 16",
                StorageCapacity = 128,
                RAM = 12,
                DisplaySize = 6.1,
                Price = 1799.99m
            };

            MobilePhone phone2 = new MobilePhone
            {
                Brand = "Samsung",
                Model = "Galaxy S25",
                StorageCapacity = 256,
                RAM = 12,
                DisplaySize = 6.2,
                Price = 999.99m
            };

            MobilePhone phone3 = new MobilePhone
            {
                Brand = "Google",
                Model = "Pixel 9",
                StorageCapacity = 128,
                RAM = 12,
                DisplaySize = 6.4,
                Price = 1699.99m
            };

            // Print details of mobile phones
            Console.WriteLine("Mobile Phone 1 Details:");
            phone1.PrintDetails();

            Console.WriteLine("Mobile Phone 2 Details:");
            phone2.PrintDetails();

            Console.WriteLine("Mobile Phone 3 Details:");
            phone3.PrintDetails();
        }
    }

    class MobilePhone
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int StorageCapacity { get; set; }
        public int RAM { get; set; }
        public double DisplaySize { get; set; }
        public decimal Price { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Storage Capacity: {StorageCapacity} GB");
            Console.WriteLine($"RAM: {RAM} GB");
            Console.WriteLine($"Display Size: {DisplaySize} inches");
            Console.WriteLine($"Price: ${Price}");
            Console.WriteLine();
        }
    }

}
