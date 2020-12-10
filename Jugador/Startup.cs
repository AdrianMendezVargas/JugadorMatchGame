using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jugador.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Jugador {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddDbContext<Contexto>(options =>
                options.UseSqlite(Configuration.GetConnectionString("SqliteString"))
            );

            services.AddCors(options => options.AddPolicy("AllowWebApp" , builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
                )
            );

        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app , IWebHostEnvironment env) {
                if (env.IsDevelopment()) {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseCors("AllowWebApp");
                

                app.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
                });
            }
        }
    }
