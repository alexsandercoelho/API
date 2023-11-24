using Domain.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infra.Database;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services;
using System.Reflection;
using WebApi.Middlewares;

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
        services.AddMvc();
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblies(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load));

        services.AddDbContext<SqlDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlDbContext")));

        services.SetupUnitOfWork();

        services.AddAutoMapper(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load));

        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IProfilesService, ProfilesService>();
        services.AddScoped<IFlagService, FlagService>();
        services.AddScoped<IFeatureService, FeatureService>();
        services.AddScoped<IEarlyBirdService, EarlyBirdService>();
        services.AddScoped<IChangesService, ChangesService>();

        var client = Configuration.GetSection("ClientHost").Value;

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
               builder => builder
                .WithOrigins(Configuration.GetSection("ClientHost").Value)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
              );
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
        }

        app.UseHttpsRedirection();

        app.UseCors("CorsPolicy");

        // Use Exception Middleware
        app.UseMiddleware<ExceptionHandler>();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}