using Contracts;
using Inclusive.Extensions;
using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NLog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// nlog configuration
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
    "/nlog.config"));


// Add services to the container.
// Cors configuration
builder.Services.ConfigureCors();
// IIS integration
builder.Services.ConfigureIISIntegration();
// Logger configuration
builder.Services.ConfigureLoggerService();
// Repository configuration
builder.Services.ConfigureRepositoryManager();
// Service configuration
builder.Services.ConfigureServiceManager();
// DbContext configuration
builder.Services.ConfigureDbContext(builder.Configuration);
// Automapper configuration
builder.Services.AddAutoMapper(typeof(Program));
// Suppress default validation
builder.Services.Configure<ApiBehaviorOptions>(option => { option.SuppressModelStateInvalidFilter = true; });
// Filters action like services
builder.Services.AddScoped<ValidationFilterAttribute>();
// Identity configuration
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
// JWT configuration
builder.Services.ConfigureJWT(builder.Configuration);
// Swagger configuration
builder.Services.ConfigureSwagger();
builder.Services.AddControllers(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
        config.InputFormatters.Insert(0,
            GetJsonPatchInputFormatter());
    })
    .AddApplicationPart(typeof(Inclusive.Presentation.AssemblyReference).Assembly)
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// custom exception
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Inclusive API V1");
    //s.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
    new ServiceCollection().AddLogging()
        .AddMvc()
        .AddNewtonsoftJson()
        .Services.BuildServiceProvider()
        .GetRequiredService<IOptions<MvcOptions>>()
        .Value.InputFormatters
        .OfType<NewtonsoftJsonPatchInputFormatter>()
        .First();