using CarSystem.DataAccess.Repository;
using CarSystem.Domain.Entities;

namespace CarSystem.Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ICarSystemRepository _service;

        public CarService(ICarSystemRepository service)
        {
            _service = service;
        }

        public ValueTask<bool> CreateApartmentAsync(Car data)
        {
            return _service.CreateApartmentAsync(data);
        }

        public ValueTask<bool> DeleteApartmentAsync(int id)
        {
            return (_service.DeleteApartmentAsync(id));
        }

        public ValueTask<IEnumerable<Car>> GetAllAsync()
        {
            return _service.GetAllAsync();
        }

        public ValueTask<Car> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }

        public ValueTask<bool> UpdateApartmentAsync(Car data)
        {
            return _service.UpdateApartmentAsync(data);
        }

    }
}
