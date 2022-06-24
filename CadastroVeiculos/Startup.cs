using CadastroVeiculos.Application.Services.Implementations;
using CadastroVeiculos.Application.Services.Interfaces;
using CadastroVeiculos.AutoMapper;
using CadastroVeiculos.Domain.Services;
using CadastroVeiculos.Infra.Data.Context;
using CadastroVeiculos.Infra.Data.Repositories.Implementations;
using CadastroVeiculos.Infra.Data.Repositories.Interfaces;
using CadastroVeiculos.Message.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CadastroVeiculos
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<CadastroVeiculosContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")
               , opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(60).TotalSeconds));
                options.UseLazyLoadingProxies(true);
            });

            services.AddMessageProjectDependencies(_configuration);

            services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile));

            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IProprietarioService, ProprietarioService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IEmailService, EmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Veiculos}/{action=Index}/{id?}");
            });
        }
    }
}
