namespace CarsAPI.Entities;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }   
    public string Model { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
    public bool Available { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }
}