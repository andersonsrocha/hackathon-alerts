using HackathonAlerts.Api.Configurations;
using HackathonAlerts.Application;
using HackathonAlerts.Data;
using HackathonAlerts.Api.Middlewares;
using HackathonAlerts.NewRelicEvent;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

#region [Database]
builder.Services.AddMongoClient(builder.Configuration);
builder.Services.AddMongoContext();
builder.Services.AddRepositories();
#endregion

#region [AutoMapper]
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
#endregion

#region [Mediator]
builder.Services.AddMediator();
#endregion

#region [Serilog]
builder.AddSerilog();
#endregion

#region [RabbitMQ]
builder.Services.AddHostedService<AlertQueue>();
#endregion

#region [Services]
builder.Services.AddNewRelicEventPublisher(builder.Configuration);
#endregion

var app = builder.Build();

app.MapSwagger("/openapi/{documentName}.json");
app.MapScalarApiReference();

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<RequestMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();