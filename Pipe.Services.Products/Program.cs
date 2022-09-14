using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.MappingConfigurators;
using Products.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.Sources.Clear();

    var env = hostingContext.HostingEnvironment;

    config.SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //load base settings
        .AddJsonFile("appsettings.Local.json", optional: false, reloadOnChange: true) //load local settings
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); //load environment settings
    // .AddEnvironmentVariables();

    if (args != null)
    {
        config.AddCommandLine(args);
    }
});

IConfiguration configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(ProductMappingConfigurator));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();