using CarSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarSystem.DataAccess
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }
        public virtual DbSet<Car> Cars { get; set; }
    }
}
