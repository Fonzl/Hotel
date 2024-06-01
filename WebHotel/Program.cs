using Repository.RepositoryCountry;
using Microsoft.AspNetCore.Identity;
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
using Repository;
using Microsoft.EntityFrameworkCore;
using Service.UserService;
using Repository.RepositoryUser;
using Repository.JwtRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebHotel;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
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
builder.Services.AddScoped(typeof(IRepositoryUser), typeof(RepositoryUser));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped(typeof(IJwtRepository), typeof(JwtRepository));

builder.Services.AddIdentityCore<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApplicationContext>();

  var app = builder.Build();
app.UseDeveloperExceptionPage();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
