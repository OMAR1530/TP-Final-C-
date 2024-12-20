using System;
using CarConstrutor;

namespace VehicleRentalManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager fleet = new CarManager();
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.Clear(); 
                Console.WriteLine("--- Fleet Management Menu ---");
                Console.WriteLine("1. Add a car");
                Console.WriteLine("2. List cars");
                Console.WriteLine("3. Rent a car");
                Console.WriteLine("4. Return a car");
                Console.WriteLine("5. Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        fleet.AddCar();
                        break;

                    case "2":
                        fleet.ListCars();
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine(); 
                        break;

                    case "3":
                        int rentId;
                        Console.Write("Car ID to rent: ");
                        while (!int.TryParse(Console.ReadLine(), out rentId) || rentId <= 0)
                        {
                        Console.WriteLine("Please enter a valid ID.");
                        Console.Write("Car ID to rent: ");
                        }
                        fleet.RentCar(rentId);
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine(); 
                        break;

                    case "4":
                        int returnId;
                        Console.Write("Car ID to return: ");
                        while (!int.TryParse(Console.ReadLine(), out returnId) || returnId <= 0)
                        {
                        Console.WriteLine("Please enter a valid ID.");
                        Console.Write("Car ID to return: ");
                        }
                        fleet.ReturnCar(returnId);
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine(); 
                        break;


                    case "5":
                        continueRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
