using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddScoped<IBusService,BusService>();
builder.Services.AddScoped<JwtService, JwtService>();
builder.Services.AddScoped<IDriverService,DriverService>();
builder.Services.AddScoped<IScheduleService,ScheduleService>();
builder.Services.AddScoped<IStopService,StopService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IStationService,StationService>();
builder.Services.AddScoped<IPathService,PathService>();
builder.Services.AddLogging(a=>a.AddConsole());
builder.Services.AddSwaggerGen(c=>{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Введите: Bearer {your JWT token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });}
);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var key = Encoding.UTF8.GetBytes(
            builder.Configuration["Jwt:Key"]);

        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey =
                    new SymmetricSecurityKey(key)
            };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbcontext>(o=>o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<RequestTimeMiddleware>();
app.MapOpenApi();
app.MapControllers();
app.Run();

