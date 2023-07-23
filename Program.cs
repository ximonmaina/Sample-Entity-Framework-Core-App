using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp;
using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.HelperExtensions;
using MyFirstEfCoreApp.ServiceLayer.AdminServices.Concrete;
using MyFirstEfCoreApp.ServiceLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options
    //.UseLazyLoadingProxies()
    .UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        );
});

// register services
builder.Services.AddTransient<IBookFilterDropDownService, BookFilterDropDownService>();
builder.Services.AddTransient<IChangePubDateService, ChangePubDateService>();
builder.Services.AddTransient<IChangePriceOfferService, ChangePriceOfferService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// apply database updates
await app.SetupDatabaseAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
