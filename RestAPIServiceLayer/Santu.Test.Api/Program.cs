global using ContentRepository.Infrastructure;
using Santu.Test.Api;
using Santu.Test.Api.Middleware;

//private readonly IWebHostEnvironment _environment;

//environment = environment ?? throw new ArgumentNullException(nameof(environment));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddContentRepositoryServices();

builder.Services.AddDbContext<ContentRepositoryContext>();

var app = builder.Build();

app.SetClaimsAsServiceArgs();
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
