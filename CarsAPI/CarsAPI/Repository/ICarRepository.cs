using CarsAPI.Entities;

namespace CarsAPI.Repository;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAvailableCars();
}