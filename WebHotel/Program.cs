using Repository.RepositoryCountry;
using Service.ServiceCountry;
using Repository.RepositoryCity;
using Service.ServiceCity;
using Repository.RepositoryHotel;
using Service.ServiceHotel;
using Repository.RepositoryHotel—hain;
using Service.ServiceHotelChain;
using Repository.RepositoryHotelRoom;
using Service.ServiceHotelRoom;
using Repository.RepositoryTypeOfNumber;
using Service.ServiceTypeOfNumber;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddScoped(typeof(ICityRepository), typeof(CityRepository));
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddScoped(typeof(IRepositoryHotel), typeof(RepositoryHotel));
builder.Services.AddTransient<IServiceHotel, ServiceHotel>();
builder.Services.AddScoped(typeof(IHotelChainRepository), typeof(HotelChainRepository));
builder.Services.AddTransient<IServiceHotelChain, ServiceHotelChain>();
builder.Services.AddScoped(typeof(IRepositoryHotelRoom), typeof(RepositoryHotelRoom));
builder.Services.AddTransient<IServiceHotelRoom, ServiceHotelRoom>();
builder.Services.AddScoped(typeof(IRepositoryTypeOfNumber), typeof(RepositoryTypeOfNumber));
builder.Services.AddTransient<IServiceTypeOfNumber, ServiceTypeOfNumber>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
