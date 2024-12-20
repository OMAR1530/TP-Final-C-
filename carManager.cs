using System;
using CarConstrutor;


    public class CarManager
    {
        private List<Car> cars = new List<Car>();
        private int nextId = 1; 

       private readonly Dictionary<string, List<string>> predefinedCars = new Dictionary<string, List<string>>
{
    { "Toyota", new List<string> { "Corolla", "Camry", "Yaris", "RAV4", "Highlander", "Prius", "Land Cruiser" } },
    { "BMW", new List<string> { "X5", "X3", "3 Series", "5 Series", "7 Series", "M3", "M5" } },
    { "Audi", new List<string> { "A3", "A4", "A5", "A6", "Q3", "Q5", "Q7", "R8" } },
    { "Mercedes-Benz", new List<string> { "C-Class", "E-Class", "S-Class", "GLC", "GLE", "CLA", "A-Class" } },
    { "Honda", new List<string> { "Civic", "Accord", "CR-V", "HR-V", "Pilot", "Insight", "Fit" } },
    { "Ford", new List<string> { "Focus", "Fiesta", "Mustang", "Explorer", "Escape", "F-150", "Edge" } },
    { "Chevrolet", new List<string> { "Malibu", "Cruze", "Silverado", "Equinox", "Tahoe", "Traverse", "Camaro" } },
    { "Nissan", new List<string> { "Altima", "Sentra", "Maxima", "Rogue", "Murano", "Pathfinder", "GT-R" } },
    { "Hyundai", new List<string> { "Elantra", "Sonata", "Tucson", "Santa Fe", "Kona", "Ioniq", "Palisade" } },
    { "Kia", new List<string> { "Soul", "Optima", "Sportage", "Sorento", "Telluride", "Rio", "Stinger" } },
    { "Volkswagen", new List<string> { "Golf", "Passat", "Tiguan", "Jetta", "Beetle", "Arteon", "Atlas" } },
    { "Tesla", new List<string> { "Model 3", "Model S", "Model X", "Model Y", "Cybertruck", "Roadster" } },
    { "Mazda", new List<string> { "Mazda3", "Mazda6", "CX-5", "CX-30", "MX-5 Miata", "CX-9" } },
    { "Volvo", new List<string> { "XC40", "XC60", "XC90", "S60", "S90", "V60", "V90" } },
    { "Jeep", new List<string> { "Wrangler", "Cherokee", "Grand Cherokee", "Renegade", "Compass", "Gladiator" } }
};
        public void AddCar()
        {
            Console.Clear();
            Console.WriteLine("Choose a brand:");
            int index = 1;
            var brands = predefinedCars.Keys.ToList();
            foreach (var brand in brands)
            {
                Console.WriteLine($"{index}. {brand}");
                index++;
            }

            int brandChoice = GetUserChoice(1, brands.Count);
            string chosenBrand = brands[brandChoice - 1];

            Console.Clear();
            Console.WriteLine($"Choose a model for {chosenBrand}:");
            var models = predefinedCars[chosenBrand];
            index = 1;
            foreach (var model in models)
            {
                Console.WriteLine($"{index}. {model}");
                index++;
            }

            int modelChoice = GetUserChoice(1, models.Count);
            string chosenModel = models[modelChoice - 1];

            Console.Clear();
            int year = GetValidYear();
            var newCar = new Car(nextId++, chosenBrand, chosenModel, year);
            cars.Add(newCar);
            Console.WriteLine("Car added successfully!");
        }

        public void ListCars()
        {
            Console.Clear();
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars in the fleet.");
                return;
            }

            foreach (var car in cars)
            {
                car.DisplayInformation();
            }
        }

        public void RentCar(int id)
        {
            Console.Clear();
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            if (car.IsRented)
            {
                Console.WriteLine("This car is already rented.");
            }
            else
            {
                car.IsRented = true;
                Console.WriteLine("Car rented successfully!");
            }
        }

        public void ReturnCar(int id)
        {
            Console.Clear();
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            if (!car.IsRented)
            {
                Console.WriteLine("This car is not rented.");
            }
            else
            {
                car.IsRented = false;
                Console.WriteLine("Car returned successfully!");
            }
        }

        private int GetUserChoice(int min, int max)
        {
            int choice;
            do
            {
                Console.Write($"Enter your choice ({min}-{max}): ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max);

            return choice;
        }

        private int GetValidYear()
        {
            int year;
            int currentYear = DateTime.Now.Year;

            do
            {
                Console.Write($"Enter the year of manufacture (1900-{currentYear}): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out year) || year < 1900 || year > currentYear)
                {
                    Console.WriteLine("Invalid input. Please enter a valid year.");
                }
                else
                {
                    break;
                }
            } while (true);

            return year;
        }
    }
