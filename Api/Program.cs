using Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddSingleton<PeopleService>();
builder.Services
    .AddAuthentication()
    .AddJwtBearer();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Make the implicit Program class public for tests
public partial class Program { }
