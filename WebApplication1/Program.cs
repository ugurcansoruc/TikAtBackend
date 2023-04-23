using Business.Abstract;
using Business.Concreate;
using DataAccess.Abstract;
using DataAccess.Concreate.EfPostgreSQL;
using DataAccess.Concrete.EfPostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EfPSqlDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));
            builder.Services.AddScoped<IUserDal, EfPSqlUserDal>();
            builder.Services.AddScoped<IUserService, UserManager>();
            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add AWS Lambda support.
            builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}