using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;

//ajuda a criar e configurar o servidor web, que � respons�vel por lidar com as requisi��es e gerar as respostas para a aplica��o.
var builder = WebApplication.CreateBuilder(args);

//conectando com o banco mysql e informando os dados do banco como root, password, etc
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContext<FilmeContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//para usar o auto mapper em toda a aplica��o
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
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
