using AutoMapper;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using OrderProcessingApi.Data;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Mappers;
using OrderProcessingApi.Services.ApiServices;
using OrderProcessingApi.Services.ApiServices.Interfaces;
using OrderProcessingApi.Services.Inventory;
using OrderProcessingApi.Services.Inventory.Interfaces;
using OrderProcessingApi.Services.Users;
using OrderProcessingApi.Services.Users.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Inventory Fetchers
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IWooInventoryFetcher, WooInventoryFetcher>();

// Add services to the container.
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserValidationService, UserValidationService>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<ITransactionManager, TransactionManager>();

//Api Services
builder.Services.AddScoped<IFetchWooApiService, FetchWooApiService>();


//Add Mappers
builder.Services.AddSingleton(new MapperConfiguration(mc =>
{
    mc.AddProfile(new WooProductProfile());
    mc.AddProfile(new ProductProfile());
    mc.AddProfile(new UserDtoProfile());
    mc.AddProfile(new UserGatewayProfile());
    mc.AddProfile(new ProductGatewayProfile());
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();
var Configuration = app.Configuration;


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();