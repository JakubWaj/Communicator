namespace CarsAPI.Entities;

public class Rental
{
    public int CarId { get; set; }
    public int Client { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public double TotalCost { get; set; }
}