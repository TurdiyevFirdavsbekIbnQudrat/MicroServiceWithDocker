using CarSystem.Domain.Entities;
using CarSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarSystemController : ControllerBase
    {
        private readonly ICarService _service;

        public CarSystemController(ICarService apartmentService)
        {
            _service = apartmentService;
        }

        [HttpGet]
        public ValueTask<IEnumerable<Car>> GetAll()
        {
            return _service.GetAllAsync();
        }
        [HttpGet]
        public ValueTask<Car> GetById(int id)
        {
            return _service.GetByIdAsync(id);
        }
        [HttpPost]
        public ValueTask<bool> Create(Car data)
        {
            return _service.CreateApartmentAsync(data);
        }
        [HttpPut]
        public ValueTask<bool> Update(Car data)
        {
            return _service.UpdateApartmentAsync(data);
        }
        [HttpDelete]
        public ValueTask<bool> DeleteById(int id)
        {
            return _service.DeleteApartmentAsync(id);
        }

    }
}
