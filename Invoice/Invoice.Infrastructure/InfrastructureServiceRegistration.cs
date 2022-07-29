using Invocie.Core.Contratcs.Infra;
using Invocie.Core.Contratcs.Persistence;
using Invocie.Core.Models;
using Invoice.Infrastructure.Mail;
using Invoice.Infrastructure.Persistence;
using Invoice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Invoice.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvoiceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("InvoiceConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
