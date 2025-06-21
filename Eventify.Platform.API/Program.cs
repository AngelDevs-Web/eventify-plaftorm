using Eventify.Platform.API.Shared.Domain.Repositories;
using Eventify.Platform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Eventify.Platform.API.SocialEvents.Application.ACL;
using Eventify.Platform.API.SocialEvents.Application.Internal.CommandServices;
using Eventify.Platform.API.SocialEvents.Application.Internal.QueryServices;
using Eventify.Platform.API.SocialEvents.Domain.Repositories;
using Eventify.Platform.API.SocialEvents.Domain.Services;
using Eventify.Platform.API.SocialEvents.Infrastructure.Persistance.EFC.Repositories;
using Eventify.Platform.API.SocialEvents.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add ASP.NET Core MVC with kebab Case Route Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddEndpointsApiExplorer();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Configuration For Entity Framework Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});


// Add Swagger/OpenAPI support
builder.Services.AddSwaggerGen(options => {
    options.EnableAnnotations();
});

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// SocialEvents Bounded Context - Dependency Injection
builder.Services.AddScoped<ISocialEventRepository, SocialEventRepository>();
builder.Services.AddScoped<ISocialEventCommandService, SocialEventCommandService>();
builder.Services.AddScoped<ISocialEventQueryService, SocialEventQueryService>();
builder.Services.AddScoped<ISocialEventContextFacade, SocialEventContextFacade>();




var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}
// Configure SocialEvents model at startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    // Ensure database is created with SocialEvents configuration
    context.Database.EnsureCreated();
 
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var modelBuilder = new ModelBuilder();
    
    Eventify.Platform.API.SocialEvents.Infrastructure.Persistance.EFC.Configuration.Extensions
        .ModelBuilderExtensions.ApplySocialEventsConfiguration(modelBuilder);
}



// Use Swagger for API documentation if in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();