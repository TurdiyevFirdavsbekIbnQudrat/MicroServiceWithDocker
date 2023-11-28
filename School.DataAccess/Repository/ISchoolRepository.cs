using School.Domain.Entities;

namespace School.DataAccess.Repository
{
    public interface ISchoolRepository
    {
        public ValueTask<bool> CreateApartmentAsync(Schools data);
        public ValueTask<bool> UpdateApartmentAsync(Schools data);
        public ValueTask<bool> DeleteApartmentAsync(int id);
        public ValueTask<IEnumerable<Schools>> GetAllAsync();
        public ValueTask<Schools> GetByIdAsync(int id);

    }
}
