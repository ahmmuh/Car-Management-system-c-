using CarApplikation.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApplikation.Data
{
    public class CarDbContext: DbContext
    {

        public CarDbContext(DbContextOptions<CarDbContext> options):base(options)
        {

        }

        public DbSet<Car> cars { get; set; }
    }

}
