using LibraryManagementApi.Data;
using LibraryManagementApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDb")));
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();
app.UseRouting();
app.UseCors();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();
