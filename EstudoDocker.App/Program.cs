using EstudoDocker.App;
using EstudoDocker.Application.AutpMappers;
using EstudoDocker.Application.Interfaces;
using EstudoDocker.Application.Services;
using EstudoDocker.ConfigKafka.ConfigKafka;
using EstudoDocker.ConfigKafka.Repository;
using EstudoDocker.DataBase.AutoMappers;
using EstudoDocker.DataBase.Context;
using EstudoDocker.DataBase.Repositories;
using EstudoDocker.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<EstudoDockerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EstudoDockerDB")));


builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IKafkaRepository, KafkaRepository>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IKafkaService, KafkaService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new AutoMaperDataProfile());
});
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new AutoMaperApplicationProfile());
});
builder.Services.AddSingleton<KafkaConfig>();

builder.Services.AddHostedService<Worker>();

var app = builder.Build();


app.Run();
