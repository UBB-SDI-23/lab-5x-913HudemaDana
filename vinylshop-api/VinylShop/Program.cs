using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services;
using VinylShop.Utils.Profile;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow all",
        policy =>
        {
            policy.WithOrigins("http://localhost")
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials();
        });
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

var config = new AutoMapper.MapperConfiguration(options =>
    options.AddProfile(new ApplicationProfile()));
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IBandService, BandService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IRecordLabelService, RecordLabelService>();
builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IVinylService, VinylService>();

builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors("Allow all");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseAuthorization();

app.MapControllers();

app.Run();