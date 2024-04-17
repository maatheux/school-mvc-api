using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;

var builder = WebApplication.CreateBuilder(args);
{
    ConfigureServices(builder);
}

var app = builder.Build();
{
    app.MapHealthChecks("/health");
}

app.Run();

void ConfigureServices(WebApplicationBuilder webApplicationBuilder)
{
    string connectionString = webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection")!;
    webApplicationBuilder.Services.AddDbContext<SchoolDataContext>(options => 
        options.UseSqlServer(connectionString));
    webApplicationBuilder.Services.AddHealthChecks();
}
