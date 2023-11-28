using Apartment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.DataAccess.Repository
{
    public interface IApartmentRepository
    {
        public ValueTask<bool> CreateApartmentAsync(ApartmentData data);
        public ValueTask<bool> UpdateApartmentAsync(ApartmentData data);
        public ValueTask<bool> DeleteApartmentAsync(int id);
        public ValueTask<IEnumerable<ApartmentData>> GetAllAsync(); 
        public ValueTask<ApartmentData> GetByIdAsync(int id);
    }
}
