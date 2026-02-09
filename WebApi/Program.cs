using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddScoped<IBusService,BusService>();
builder.Services.AddScoped<IDriverService,DriverService>();
builder.Services.AddScoped<IScheduleService,ScheduleService>();
builder.Services.AddScoped<IStopService,StopService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IStationService,StationService>();
builder.Services.AddScoped<IPathService,PathService>();
builder.Services.AddLogging(a=>a.AddConsole());
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbcontext>(o=>o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestTimeMiddleware>();
app.MapOpenApi();
app.MapControllers();
app.Run();

