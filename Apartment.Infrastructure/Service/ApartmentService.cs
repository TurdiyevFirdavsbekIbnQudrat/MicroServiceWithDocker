using Apartment.DataAccess.Repository;
using Apartment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Infrastructure.Service
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _service;

        public ApartmentService(IApartmentRepository service)
        {
            _service = service;
        }

        public ValueTask<bool> CreateApartmentAsync(ApartmentData data)
        {
            return _service.CreateApartmentAsync(data);
        }

        public ValueTask<bool> DeleteApartmentAsync(int id)
        {
            return (_service.DeleteApartmentAsync(id));
        }

        public ValueTask<IEnumerable<ApartmentData>> GetAllAsync()
        {
            return _service.GetAllAsync();
        }

        public ValueTask<ApartmentData> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }

        public ValueTask<bool> UpdateApartmentAsync(ApartmentData data)
        {
            return _service.UpdateApartmentAsync(data);
        }
    }
}
