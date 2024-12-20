namespace CarConstrutor
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsRented { get; set; }

        public Car(int id, string brand, string model, int year)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            IsRented = false;
        }

        public void DisplayInformation()
        {
            string status = IsRented ? "Rented" : "Available";
            Console.WriteLine($"ID: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Status: {status}");
        }
    }
}
