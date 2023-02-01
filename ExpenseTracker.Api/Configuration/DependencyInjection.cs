using ExpenseTracker.Core.Contracts;
using ExpenseTracker.Core.Service;
using ExpenseTracker.Core.Servie;
using ExpenseTracker.Infrastructure;
using ExpenseTracker.Infrastructure.Mappers;
using ExpenseTracker.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContainerService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(ExpenseProfile));
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
            // services.AddScoped<ExpenseRepository, IExpenseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            // services.AddScoped<CategoryRepository, ICategoryRepository>();
            

            return services;
        }
    }
}