
using EgyptWalks.Controllers;
using EgyptWalks.Data;
using EgyptWalks.Mappings;
using EgyptWalks.Repositiory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EgyptWalks
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
            builder.Services.AddDbContext<EgypWalksDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("EgyptWalksConnectionString"));
            });

            builder.Services.AddAutoMapper(cgf =>
            {
                cgf.AddProfile<AutoMapperProfiles>();
            });

            builder.Services.AddScoped<IRegionRepositiory, SQLRegionRepositiory>();

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
