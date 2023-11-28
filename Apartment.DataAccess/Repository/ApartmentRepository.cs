using Apartment.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.DataAccess.Repository
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApartmentRepository> _logger;

        public ApartmentRepository(ApplicationDbContext context, ILogger<ApartmentRepository> logger )
        {
            _context = context;
            _logger = logger;
        }

        public async ValueTask<bool> CreateApartmentAsync(ApartmentData data)
        {
            try
            {
               await _context.Apartments.AddAsync(data);
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
                var Ochiriladi = await _context.Apartments.FirstOrDefaultAsync(x => x.Id == id);
                _context.Apartments.Remove(Ochiriladi);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
        }

        public async ValueTask<IEnumerable<ApartmentData>> GetAllAsync()
        {
            try
            {
                var Hammasi = await _context.Apartments.ToListAsync(); 
                return Hammasi;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return Enumerable.Empty<ApartmentData>();
            }

        }

        public async ValueTask<ApartmentData> GetByIdAsync(int id)
        {
            try
            {
                ApartmentData Hammasi = await _context.Apartments.FirstOrDefaultAsync(x=>x.Id==id);
                return Hammasi;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return new ApartmentData() { };
            }

        }

        public async ValueTask<bool> UpdateApartmentAsync(ApartmentData data)
        {

            try
            {
                var Yangilanadi = await _context.Apartments.FirstOrDefaultAsync(x => x.Id == data.Id);
                Yangilanadi.Name = data.Name;
                Yangilanadi.address = data.address;
                Yangilanadi.Description = data.Description;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex) 
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
        }
    }
}
