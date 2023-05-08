using Business.Abstract;
using Business.Concreate;
using Core.Features.Commands.User.CreateUser;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concreate;
using Entities.Concreate.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddScoped<IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>, CreateUserCommandHandler>();


            builder.Services.AddDbContext<EfPSqlDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));
            builder.Services.AddIdentity<User,Role>().AddEntityFrameworkStores<EfPSqlDbContext>();


            // IRepositoryFactory, IUserRepository, IUserService ve IUnitOfWork ekleyin
            builder.Services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(provider.GetService<EfPSqlDbContext>()));
            builder.Services.AddScoped<IRepositoryFactory>(provider => new RepositoryFactory(provider.GetService<EfPSqlDbContext>()));
            builder.Services.AddScoped<IUserRepository>(provider => new UserRepository(provider.GetService<EfPSqlDbContext>()));
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
          
            try
            {
                var serviceProvider = builder.Services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetService<EfPSqlDbContext>();
                context.Database.Migrate();
            }
            catch
            {
            }

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