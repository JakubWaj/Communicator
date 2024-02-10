namespace CarsAPI.Entities;

public class Rental
{
    public int CarId { get; set; }
    public int ClientId { get; set; }
    public virtual Car Car { get; set; }
    public virtual Client Client { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public double TotalCost { get; set; }
}