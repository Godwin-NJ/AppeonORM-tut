using SnapObjects.Data;
using SnapObjects.Data.SqlServer;
using Appeon.SnapObjectsDemo.Service.DataContext;
using Appeon.SnapObjectsDemo.Service.Services.Impl;
using Appeon.SnapObjectsDemo.Service.Services;

namespace Appeon.SnapObjectsDemo.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ISalesOrderService, SalesOrderService>();
            builder.Services.AddDataContext<AppeonDataContext>(m => m.UseSqlServer(builder.Configuration["ConnectionStrings:AdventureWorks2012"]));
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
