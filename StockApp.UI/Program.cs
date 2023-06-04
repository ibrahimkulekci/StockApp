using StockApp.Business.Abstract;
using StockApp.Business.Concrete;
using StockApp.Data.Abstract;
using StockApp.Data.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//
builder.Services.AddTransient<IStockTypeDal, EfCoreStockTypeDal>();
builder.Services.AddTransient<IStockTypeService, StockTypeManager>();

builder.Services.AddTransient<IStockUnitDal, EfCoreStockUnitDal>();
builder.Services.AddTransient<IStockUnitService, StockUnitManager>();

builder.Services.AddTransient<IQuantityUnitDal, EfCoreQuantityUnitDal>();
builder.Services.AddTransient<IQuantityUnitService, QuantityUnitManager>();

builder.Services.AddTransient<ICurrencyDal, EfCoreCurrencyDal>();
builder.Services.AddTransient<ICurrencyService, CurrencyManager>();

builder.Services.AddTransient<IStockDal, EfCoreStockDal>();
builder.Services.AddTransient<IStockService, StockManager>();

builder.Services.AddTransient<IStockClassDal, EfCoreStockClassDal>();
builder.Services.AddTransient<IStockClassService, StockClassManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
