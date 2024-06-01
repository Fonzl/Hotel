using Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Repository;

public class ApplicationContext : IdentityUserContext<IdentityUser>
{
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //}
    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }
    public DbSet<Country> countries { get; set; }
            public DbSet<City> citys { get; set; }
            public DbSet<Hotel> hotels { get; set; }
            public DbSet<HotelRoom> hotelrooms { get; set; }
            public DbSet<HotelChain> hotelchains { get; set; }
            public DbSet<TypeOfNumber> types { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WebHostel;Username=postgres;Password=1710");
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{

    //    base.OnModelCreating(modelBuilder);
    //    new CityMap(modelBuilder.Entity<City>());
    //    new CountryMap(modelBuilder.Entity<Country>());
    //    new HotelMap(modelBuilder.Entity<Hotel>());
    //    new HotelRoomMap(modelBuilder.Entity<HotelRoom>());
    //    new HotelChainMap(modelBuilder.Entity<HotelChain>());
    //    new TypeOfNumberMap(modelBuilder.Entity<TypeOfNumber>());



    //}
}
    

