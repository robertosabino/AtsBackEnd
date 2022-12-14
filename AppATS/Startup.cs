using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppATS.Models;
using AppATS.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;

namespace AppATS
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
      });  
      services.AddScoped<ICandidatoRepository, CandidatoRepository>();
      services.AddScoped<IVagaRepository, VagaRepository>();
      services.AddControllers();
      //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
      //{
      //  options.RequireHttpsMetadata = false;
      //  options.SaveToken = true;
      //  options.TokenValidationParameters = new TokenValidationParameters()
      //  {
      //    ValidateIssuer = true,
      //    ValidateAudience = true,
      //    ValidAudience = Configuration["Jwt:Audience"],
      //    ValidIssuer = Configuration["Jwt:Issuer"],
      //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
      //  };
      //});
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo() { Title = "AtsAPI", Version = "v1" });
      });
      services.AddCors(c =>
      {
        c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseStatusCodePages();
        app.UseDeveloperExceptionPage();
      }

      app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
     
      app.UseCors(options => options.AllowAnyOrigin());

      app.UseHttpsRedirection();

      app.UseRouting();

      //app.UseAuthentication();

      //app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      //Ativa o Swagger
      app.UseSwagger();

      // Ativa o Swagger UI
      app.UseSwaggerUI(opt =>
      {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "GslAPI V1");
      });            
    }  
  }
}
