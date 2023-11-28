using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using School.Domain;
using School.Domain.Entities;

namespace School.DataAccess.Repository
{
    public class SchoolRepository : ISchoolRepository
    {

        private readonly SchoolDbContext _context;
        private readonly ILogger<SchoolRepository> _logger;

        public SchoolRepository(SchoolDbContext context, ILogger<SchoolRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async ValueTask<bool> CreateApartmentAsync(Schools data)
        {
            try
            {
                await _context.Maktablar.AddAsync(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
        }

        public async ValueTask<bool> DeleteApartmentAsync(int id)
        {
            try
            {
                var Ochiriladi = await _context.Maktablar.FirstOrDefaultAsync(x => x.Id == id);
                _context.Maktablar.Remove(Ochiriladi);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
        }

        public async ValueTask<IEnumerable<Schools>> GetAllAsync()
        {
            try
            {
                var Hammasi = await _context.Maktablar.ToListAsync();
                return Hammasi;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return Enumerable.Empty<Schools>();
            }

        }

        public async ValueTask<Schools> GetByIdAsync(int id)
        {
            try
            {
                Schools Hammasi = await _context.Maktablar.FirstOrDefaultAsync(x => x.Id == id);
                return Hammasi;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return new Schools() { };
            }

        }

        public async ValueTask<bool> UpdateApartmentAsync(Schools data)
        {

            try
            {
                var Yangilanadi = await _context.Maktablar.FirstOrDefaultAsync(x => x.Id == data.Id);
                Yangilanadi.Name = data.Name;
                Yangilanadi.Description = data.Description;
                Yangilanadi.Established = data.Established;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
        }

    }
}
