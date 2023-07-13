using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp;
using MyFirstEfCoreApp.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        );
});

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

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}



app.UseAuthorization();

app.MapControllers();

app.Run();

//Console.WriteLine("Commands: l (list), u (change url), r (resetDb) and e (exit) - add -l to first two for logs");

//Console.Write("Checking if database exists...");

//Console.WriteLine(Commands.WipeCreateSeed(true) ? "created database and seeded it." : "it exists");

//do
//{
//    Console.Write("> ");
//    var command = Console.ReadLine();
//    switch (command)
//    {
//        case "l":
//            Commands.ListAll();
//            break;
//        case "u":
//            Commands.ChangeWebUrl();
//            break;
//        case "r":
//            Commands.WipeCreateSeed(false);
//            break;
//        case "e":
//            return;
//        default:
//            Console.WriteLine("Unknown command.");
//            break;
//    }
//} while (true);