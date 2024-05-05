using Data;
using Microsoft.EntityFrameworkCore;

namespace Repository;

        public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
        {
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                new CityMap(modelBuilder.Entity<City>());
                new CountryMap(modelBuilder.Entity<Country>());
        
        
                
            }
        }
    

