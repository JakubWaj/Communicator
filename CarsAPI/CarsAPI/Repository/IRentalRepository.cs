using CarsAPI.Entities;

namespace CarsAPI.Repository;

public interface IRentalRepository
{
    Task<IEnumerable<Rental>> GetAllUserRentals(int clientId);
    Task<IEnumerable<Rental>> GetUserCurrentRentals(int clientId);
    Task AddRental(Rental rental);
    Task RemoveRental(Rental rental);
}