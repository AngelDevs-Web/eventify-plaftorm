using Eventify.Platform.API.Operation.Application.Internal.CommandServices;
using Eventify.Platform.API.Operation.Application.Internal.QueryService;
using Eventify.Platform.API.Operation.Domain.Repositories;
using Eventify.Platform.API.Operation.Domain.Services;
using Eventify.Platform.API.Operation.infrastructure.Persistence.EFC.Repositories;
using Eventify.Platform.API.Planning.Application.Internal.CommandServices;
using Eventify.Platform.API.Planning.Application.Internal.QueryServices;
using Eventify.Platform.API.Planning.Domain.Repositories;
using Eventify.Platform.API.Planning.Domain.Services;
using Eventify.Platform.API.Planning.Infrastructure.Persistence.EFC.Repositories;
using Eventify.Platform.API.Profiles.Application.ACL;
using Eventify.Platform.API.Profiles.Application.Internal.CommandServices;
using Eventify.Platform.API.Profiles.Application.Internal.QueryServices;
using Eventify.Platform.API.Profiles.Domain.Repositories;
using Eventify.Platform.API.Profiles.Domain.Services;
using Eventify.Platform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using Eventify.Platform.API.Profiles.Interfaces.ACL;
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

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });

// Add Swagger/OpenAPI support
builder.Services.AddSwaggerGen(options => {
    options.EnableAnnotations();
});

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Planning Bounded Context

builder.Services.AddScoped<IQuoteRepository, QuoteRepository>();
builder.Services.AddScoped<IQuoteCommandService, QuoteCommandService>();
builder.Services.AddScoped<IQuoteQueryService, QuoteQueryService>();

builder.Services.AddScoped<IServiceItemRepository, ServiceItemRepository>();
builder.Services.AddScoped<IServiceItemCommandService, ServiceItemCommandService>();
builder.Services.AddScoped<IServiceItemQueryService, ServiceItemQueryService>();

// SocialEvents Bounded Context - Dependency Injection
builder.Services.AddScoped<ISocialEventRepository, SocialEventRepository>();
builder.Services.AddScoped<ISocialEventCommandService, SocialEventCommandService>();
builder.Services.AddScoped<ISocialEventQueryService, SocialEventQueryService>();
builder.Services.AddScoped<ISocialEventContextFacade, SocialEventContextFacade>();


// Profiles Bounded Context
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();

// Operation Bounded Context
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
builder.Services.AddScoped<IReviewQueryService,ReviewQueryService>();

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