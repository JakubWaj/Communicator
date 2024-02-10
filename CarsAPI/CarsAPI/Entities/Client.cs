namespace CarsAPI.Entities;

public class Client
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }
}