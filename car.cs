namespace CarConstrutor
{
    public class Car
    {
        // Propriétés représentant les attributs d'une voiture
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsRented { get; set; }

        // Constructeur pour initialiser une nouvelle voiture
        public Car(int id, string brand, string model, int year)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            IsRented = false; // La voiture est disponible par défaut
        }

        // Affiche les informations de la voiture, incluant son statut (louée ou disponible)
        public void DisplayInformation()
        {
            string status = IsRented ? "Rented" : "Available"; // Détermine si la voiture est louée ou disponible
            Console.WriteLine($"ID: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Status: {status}");
        }
    }
}
