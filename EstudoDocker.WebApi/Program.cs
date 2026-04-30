using EstudoDocker.Application.AutpMappers;
using EstudoDocker.Application.Interfaces;
using EstudoDocker.Application.Services;
using EstudoDocker.ConfigKafka.ConfigKafka;
using EstudoDocker.ConfigKafka.Repository;
using EstudoDocker.DataBase.AutoMappers;
using EstudoDocker.DataBase.Context;
using EstudoDocker.DataBase.Repositories;
using EstudoDocker.Domain.Interfaces.Repository;
using EstudoDocker.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EstudoDockerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EstudoDockerDB")));

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IKafkaRepository, KafkaRepository>();
builder.Services.AddScoped<IPessoaService,PessoaService>();
builder.Services.AddScoped<IKafkaService, KafkaService>();

builder.Services.AddTransient<GlobalException>();

builder.Services.AddAutoMapper(cfg => 
{ 
    cfg.AddProfile(new AutoMaperDataProfile()); 
});
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new AutoMaperApplicationProfile());
});
builder.Services.AddSingleton<KafkaConfig>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalException>();

app.MapControllers();

app.Run();
