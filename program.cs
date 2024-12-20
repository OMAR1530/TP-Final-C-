using System;
using CarConstrutor;

namespace VehicleRentalManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager fleet = new CarManager();  // Création d'une instance de CarManager pour gérer la flotte
            bool continueRunning = true;  // Variable pour contrôler la boucle du menu

            while (continueRunning)
            {
                Console.Clear();  // Efface l'écran pour une nouvelle itération du menu
                Console.WriteLine("--- Fleet Management Menu ---");
                Console.WriteLine("1. Add a car");
                Console.WriteLine("2. List cars");
                Console.WriteLine("3. Rent a car");
                Console.WriteLine("4. Return a car");
                Console.WriteLine("5. Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();  // Récupère l'option choisie par l'utilisateur
                switch (choice)
                {
                    case "1":
                        fleet.AddCar();  // Appelle la méthode AddCar pour ajouter une voiture
                        break;

                    case "2":
                        fleet.ListCars();  // Appelle la méthode ListCars pour afficher la liste des voitures
                        Console.WriteLine("\nPress Enter to continue..."); 
                        Console.ReadLine();  // Attend que l'utilisateur appuie sur Entrée pour continuer
                        break;

                    case "3":
                        int rentId;
                        Console.Write("Car ID to rent: ");
                        // Demande à l'utilisateur de saisir un ID valide pour louer une voiture
                        while (!int.TryParse(Console.ReadLine(), out rentId) || rentId <= 0)
                        {
                            Console.WriteLine("Please enter a valid ID.");
                            Console.Write("Car ID to rent: ");
                        }
                        fleet.RentCar(rentId);  // Appelle la méthode RentCar pour louer la voiture
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();  // Attend que l'utilisateur appuie sur Entrée pour continuer
                        break;

                    case "4":
                        int returnId;
                        Console.Write("Car ID to return: ");
                        // Demande à l'utilisateur de saisir un ID valide pour retourner une voiture
                        while (!int.TryParse(Console.ReadLine(), out returnId) || returnId <= 0)
                        {
                            Console.WriteLine("Please enter a valid ID.");
                            Console.Write("Car ID to return: ");
                        }
                        fleet.ReturnCar(returnId);  // Appelle la méthode ReturnCar pour retourner la voiture
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();  // Attend que l'utilisateur appuie sur Entrée pour continuer
                        break;

                    case "5":
                        continueRunning = false;  // Met fin à la boucle et quitte le programme
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();  // Attend que l'utilisateur appuie sur Entrée pour revenir au menu
                        break;
                }
            }
        }
    }
}
