using okala_task.DependencyInjection;
using okala_task.Filters;
using okala_task.Utilities;
using HttpRequest = okala_task.Utilities.HttpRequest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add<UnhandledExceptionFilterAttribute>(); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IHttpRequest, HttpRequest>();
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAppConfigurations(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
