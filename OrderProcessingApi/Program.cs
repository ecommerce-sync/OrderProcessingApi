using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderProcessingApi.Data;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Mappers;
using OrderProcessingApi.Services;
using OrderProcessingApi.Services.ApiServices;
using OrderProcessingApi.Services.ApiServices.Interfaces;
using OrderProcessingApi.Services.Inventory;
using OrderProcessingApi.Services.Inventory.Interfaces;
using OrderProcessingApi.Services.Users;
using OrderProcessingApi.Services.Users.Interfaces;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

//Inventory Fetchers
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IWooInventoryService, WooInventoryService>();

// Add services to the container.
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserValidationService, UserValidationService>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<ITransactionManager, TransactionManager>();
builder.Services.AddScoped<IInventoryInitialiser, InventoryInitialiser>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();

//Api Services
builder.Services.AddScoped<IFetchWooApiService, FetchWooApiService>();

//Add Mappers
builder.Services.AddSingleton(new MapperConfiguration(mc =>
{
    mc.AddProfile(new ProductProfile());
    mc.AddProfile(new UserProfile());
    mc.AddProfile(new IntegrationProfile());
}).CreateMapper());

//Database
builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<Context>(options =>
        options.UseLazyLoadingProxies()
            .UseSqlServer(
                builder.Configuration.GetConnectionString("Context"))
    );

//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration.GetValue<string>("Auth:Authority");
    options.Audience = builder.Configuration.GetValue<string>("Auth:Audience");
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        NameClaimType = ClaimTypes.NameIdentifier
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

// Custom Configuration
var configuration = app.Configuration;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapControllers();

app.Run();