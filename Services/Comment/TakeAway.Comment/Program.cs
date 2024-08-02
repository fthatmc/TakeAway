using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TakeAway.Comment.DAL.Context;
using TakeAway.Comment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//postgreSQL için baðlantý konfigürasyonu

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CommentContext>(opt =>
{
    opt.UseNpgsql(connectionstring);
});

builder.Services.AddScoped<IUserCommentService, UserCommentService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
