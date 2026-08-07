using System.Data.Common;

namespace Ex1Vehicle;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car { Make = "Toyota", Model = "Corolla", Year = 2020 };
        Motorcycle motorcycle = new Motorcycle { Make = "Honda", Model = "CBR600RR", Year = 2019 };

        car.DisplayInfo();
        motorcycle.DisplayInfo();

        car.Drive();
        motorcycle.Ride();
    }
}
