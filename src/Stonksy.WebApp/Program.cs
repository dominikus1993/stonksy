using StockDataProvider;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStockDataProviderModule(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();