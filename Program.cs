using Service_Design_KLTN.DynamicFilters;
using Service_Design_KLTN.Mapper;
using Service_Design_KLTN.Models;
using Service_Design_KLTN.PageLists;
using Service_Design_KLTN.Repo.DataLandsatRepo;
using Service_Design_KLTN.Repo.DataSentinelRepo;
using Service_Design_KLTN.SortLists;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<KLTNContext>();

// Add Transient (Services)
builder.Services.AddTransient<DataLandsatService>();
builder.Services.AddTransient<DataSentinelService>();

// Add Scoped (Mapper)
builder.Services.AddScoped<DataLandsatMapper>();
builder.Services.AddScoped<DataSentinelMapper>();

//Add Transient (Interface + Services)
builder.Services.AddTransient<IDataLandsat, DataLandsatService>();
builder.Services.AddTransient<IDataSentinel, DataSentinelService>();

// GridInfo (Paging + Filtering + Sorting);
builder.Services.AddScoped<PageLists<DataLandsat>>();
builder.Services.AddScoped<FilterLists<DataLandsat>>();
builder.Services.AddScoped<SortLists<DataLandsat>>();

builder.Services.AddScoped<PageLists<DataSentinel>>();
builder.Services.AddScoped<FilterLists<DataSentinel>>();
builder.Services.AddScoped<SortLists<DataSentinel>>();

// Allow any CORS when call api
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        //builder.WithOrigins("http://localhost:800").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(devCorsPolicy);

}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
