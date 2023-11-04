using Microsoft.EntityFrameworkCore;
using MTOGO.Web.Data;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Services;

var policyName = "AllowOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        builder =>
        {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

//DBContext
builder.Services.AddDbContext<MtogoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Frederik"));
    // options.UseSqlServer(builder.Configuration.GetConnectionString("Janus"));
    // options.UseSqlServer(builder.Configuration.GetConnectionString("Julius"));
});

//Build services
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

//Build repositories
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

var app = builder.Build();

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policyName);
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();