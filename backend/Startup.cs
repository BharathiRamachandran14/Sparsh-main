using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sparsh.Repositories;
using Sparsh.Services;
using System.Reflection;
using System.IO;
using System.Text.Json.Serialization;

namespace Sparsh
{
  public class Startup
  {
    private readonly string AllowAnyOriginPolicy = "_allowAnyOrigin";

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to
    // the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy(
          name: AllowAnyOriginPolicy,
          builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
      });

          services.AddControllers().AddJsonOptions(x =>
       x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "Sparsh",
          Version = "v1"
        });

        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });

      services.AddDbContext<SparshDbContext>();

      services.AddTransient<IUserRepo, UserRepo>();
      services.AddTransient<IProductRepo, ProductRepo>();
      services.AddTransient<IWishListRepo, WishListRepo>();
      services.AddTransient<ICartRepo, CartRepo>();
   
      services.AddTransient<IAuthService, AuthService>();
      services.AddTransient<IUserService, UserService>();
      services.AddTransient<IProductService, ProductService>();
      services.AddTransient<IWishListService, WishListService>();
      services.AddTransient<ICartService, CartService>();
    }

    // This method gets called by the runtime. Use this method to configure the
    // HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                                "Sparsh v1"));
      }

      AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

      app.UseCors(AllowAnyOriginPolicy);

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

      UpdateDatabase(app);
    }

    private void UpdateDatabase(IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope())
      {
        using (var context = serviceScope.ServiceProvider.GetService<SparshDbContext>())
        {
          context.Database.Migrate();
        }
      }
    }
  }
}
