using E_commerce.Interfaces;
using E_commerce.Models;
using E_commerce.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
namespace E_commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
           // builder.Services.AddTransient(typeof(IRepoistoryPattern<>), typeof(RepoistoryPattern<>));
            builder.Services.AddAutoMapper(typeof(Program));
            var connectionString = builder.Configuration.GetConnectionString("Defualt");
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.MapControllers();
            
            app.Run();
        }
    }
}
