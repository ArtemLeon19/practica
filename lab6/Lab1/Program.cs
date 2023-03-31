using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.SQL;
using Microsoft.EntityFrameworkCore;
using DataAccess.Wrapper;

namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PracticaContext>(options => options.UseSqlServer("Server=DESKTOP-SG7FFM7;Database=Practicafin;User Id=sa;Password=12345;"));


            builder.Services.AddScoped<Domain.Wrapper.IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}