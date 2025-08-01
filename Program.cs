using Microsoft.IdentityModel.Tokens;
using EgyptWalks.Controllers;
using EgyptWalks.Data;
using EgyptWalks.Mappings;
using EgyptWalks.Repositiory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace EgyptWalks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EgypWalksDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("EgyptWalksConnectionString"));
            });

            builder.Services.AddDbContext<EgyptWalksAuthDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("EgyptWalksAuthConnectionString"));
            });

            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "EgypWalksApi", Version = "v1" });
                option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Name = "authorizations",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            },
                            Scheme = "Oauth2",
                            Name = JwtBearerDefaults.AuthenticationScheme,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddAutoMapper(cgf =>
            {
                cgf.AddProfile<AutoMapperProfiles>();
            });

            builder.Services.AddScoped<IRegionRepositiory, SQLRegionRepositiory>();

            builder.Services.AddScoped<IWalkRepoistory, SQLWalkRepository>();

            builder.Services.AddScoped<IImageRepository, LocalImageRepository>();

            builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("EgyptWalks").AddEntityFrameworkStores<EgyptWalksAuthDbContext>().AddDefaultTokenProviders() ;

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option => option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            });

            builder.Services.AddScoped<ITokenRepository, TokenRepository>();

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
