using CarSystem.Domain.Entities;

namespace CarSystem.DataAccess.Repository
{
    public interface ICarSystemRepository
    {
        public ValueTask<bool> CreateApartmentAsync(Car data);
        public ValueTask<bool> UpdateApartmentAsync(Car data);
        public ValueTask<bool> DeleteApartmentAsync(int id);
        public ValueTask<IEnumerable<Car>> GetAllAsync();
        public ValueTask<Car> GetByIdAsync(int id);

    }
}
