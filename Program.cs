using Microsoft.EntityFrameworkCore;
using CJeanPIerreAPI.Data;
using CJeanPIerreAPI.Models;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using CJeanPIerreAPI.Repositories;
using CJeanPIerreAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Inventario>();
modelBuilder.EntitySet<Producto>("Productos")
    .HasManyBinding(p=>p.CompraDetalles,"CompraDetalles");
modelBuilder.EntitySet<Proveedor>("Proveedores")
    .HasManyBinding(p=>p.Compras,"Compras");
modelBuilder.EntityType<CompraDetalle>();
modelBuilder.EntityType<Compra>();




// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseInMemoryDatabase("InMem"));
//Repos
builder.Services.AddScoped<IProductosRepo, ProductosRepo>();
builder.Services.AddScoped<IProveedorRepo, ProveedorRepo>();
builder.Services.AddScoped<ICompraRepo, CompraRepo>();
builder.Services.AddScoped<ICompraDetalleRepo, CompraDetalleRepo>();
builder.Services.AddScoped<IInventarioRepo, InventarioRepo>();
//Services
builder.Services.AddScoped<ICompraService, CompraService>();




builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy().Expand().Count()
        .AddRouteComponents(
        modelBuilder.GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();
app.UseAuthorization();

app.MapControllers();
//app.MapControllers();
PrebDb.PrepPopulation(app);

app.Run();
