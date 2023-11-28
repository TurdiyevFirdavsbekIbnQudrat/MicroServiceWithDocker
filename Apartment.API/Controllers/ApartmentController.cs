using Apartment.Domain.Entity;
using Apartment.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apartment.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _service;

        public ApartmentController(IApartmentService apartmentService)
        {
            _service = apartmentService;
        }

        [HttpGet]
        public ValueTask<IEnumerable<ApartmentData>> GetAll()
        {
            return _service.GetAllAsync();
        }
        [HttpGet]
        public ValueTask<ApartmentData> GetById(int id)
        {
            return _service.GetByIdAsync(id);
        }
        [HttpPost]
        public ValueTask<bool> Create(ApartmentData data)
        {
            return _service.CreateApartmentAsync(data);
        }
        [HttpPut]
        public ValueTask<bool> Update(ApartmentData data)
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
