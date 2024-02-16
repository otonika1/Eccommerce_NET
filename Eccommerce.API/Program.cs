global using Eccommerce.API.Model;
using Eccommerce.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql();/*.AddDbContext<LifeCiContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("LifeCiContext"), b => b.MigrationsAssembly("SalePortal.Core"));
});*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();
app.Run();

