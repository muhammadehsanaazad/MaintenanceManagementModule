

var builder = WebApplication.CreateBuilder(args);

const string CorsPolicy = "CorsPolicy";

// Add services to the container.

// CORS Configuration
ExtensionMethods.ConfigureCors(builder.Services, CorsPolicy);

builder.Services.AddControllers(options =>
{
    // Authorization required
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter());
});

// AutoMapper
builder.Services.AddAutoMapperServices();

// FluentValidation
builder.Services.AddFluentValidation();

// Swagger Configuration
ExtensionMethods.ConfigureSwagger(builder.Services);

// App Setting Configuration
ExtensionMethods.ConfigureAppSetting(builder.Services, builder.Configuration);

// Sql Server Configuration
ExtensionMethods.ConfigureSqlServer(builder.Services, builder.Configuration);

// Identity Configuration
ExtensionMethods.ConfigureIdentity(builder.Services);

// Authentication Configuration
ExtensionMethods.ConfigureAuthentication(builder.Services, builder.Configuration);

// Services Configuration
ExtensionMethods.ConfigureServices(builder.Services);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Exception Filter Configuration
builder.Services.AddExceptionFilter();


var app = builder.Build();

// Apply migration
app.ApplyMigrations();

// Create an admin user
await app.Services.AddAdminAccount();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Use swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}

// CORS
app.UseCors(CorsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
