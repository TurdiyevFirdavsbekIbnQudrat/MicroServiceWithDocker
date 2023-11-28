using CarSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarSystem.DataAccess.Repository
{
    public class CarSystemRepository:ICarSystemRepository
    {
        
            private readonly CarDbContext _context;
            private readonly ILogger<CarSystemRepository> _logger;

            public CarSystemRepository(CarDbContext context, ILogger<CarSystemRepository> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async ValueTask<bool> CreateApartmentAsync(Car data)
            {
                try
                {
                    await _context.Cars.AddAsync(data);
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
                    var Ochiriladi = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
                    _context.Cars.Remove(Ochiriladi);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return false;
                }
            }

            public async ValueTask<IEnumerable<Car>> GetAllAsync()
            {
                try
                {
                    var Hammasi = await _context.Cars.ToListAsync();
                    return Hammasi;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return Enumerable.Empty<Car>();
                }

            }

            public async ValueTask<Car> GetByIdAsync(int id)
            {
                try
                {
                    Car Hammasi = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
                    return Hammasi;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return new Car() { };
                }

            }

            public async ValueTask<bool> UpdateApartmentAsync(Car data)
            {

                try
                {
                    var Yangilanadi = await _context.Cars.FirstOrDefaultAsync(x => x.Id == data.Id);
                    Yangilanadi.Name = data.Name;
                    Yangilanadi.YearOfCreated = data.YearOfCreated;
                    
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
