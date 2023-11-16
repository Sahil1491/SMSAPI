using DomainLayer.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepo;
using RepositoryLayer.Repo;
using ServiceLayer.IService;
using ServiceLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabaseConnection")));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Repository Configuration
builder.Services.AddScoped(typeof(IReportRepo<>), typeof(ReportRepo<>));
#endregion

#region Service Configuration
builder.Services.AddScoped<IReportService, ReportService>();
#endregion

// Enable Cross-Origin Resource Sharing (CORS) for any origin, method, and header
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(); // Enable CORS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();