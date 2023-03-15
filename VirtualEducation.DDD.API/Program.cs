using Microsoft.EntityFrameworkCore;
using VirtualEducation.DDD.Domain.UseCases.Gateways;
using VirtualEducation.DDD.Domain.UseCases.Gateways.RepositoriesEvents;
using VirtualEducation.DDD.Domain.UseCases.UseCases;
using VirtualEducation.DDD.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("urlConnection"),
                    b => b.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName)
));

builder.Services.AddScoped(typeof(IStoredEventRepository<>), typeof(StoredEventRepository<>));
builder.Services.AddScoped<IStudentUseCaseGateway, StudentUseCase>();
builder.Services.AddScoped<ITeacherUseCaseGateway, TeacherUseCase>();
builder.Services.AddScoped<IClassroomUseCaseGateway, ClassroomUseCase>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    context.Database.Migrate();
}

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
