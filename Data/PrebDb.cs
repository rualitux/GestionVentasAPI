using CJeanPIerreAPI.Models;
using CJeanPIerreAPI.Data;

namespace CJeanPIerreAPI.Data
{
    public static class PrebDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Productos.Any())
            {
                Console.WriteLine("Seedeando data... checa el API sobrino");
                context.Enumerados.AddRange(
                    new Enumerado() { Valor ="Categoria" }, //1
                    new Enumerado() { Valor = "Ajuste"},
                    new Enumerado() { Valor = "Movimiento", Padre = 2 },
                    new Enumerado() { Valor = "Alta de Inventario", Padre = 2 },
                    new Enumerado() { Valor = "Incremento", Padre = 2 },
                    new Enumerado() { Valor = "Decremento", Padre = 2 },
                    new Enumerado() { Valor = "Baja de Inventario", Padre = 2 },
                    new Enumerado() { Valor = "Pan y Cereales", Padre = 1 },
                    new Enumerado() { Valor = "Carne", Padre = 1 },
                    new Enumerado() { Valor = "Pescados y Mariscos", Padre = 1 },
                    new Enumerado() { Valor = "Leche, Queso y Huevos", Padre = 1 },
                    new Enumerado() { Valor = "Aceites y Grasas", Padre = 1 },
                    new Enumerado() { Valor = "Frutas", Padre = 1 },
                    new Enumerado() { Valor = "Hortalizas, Legumbres y Tubérculos", Padre = 1 },
                    new Enumerado() { Valor = "Azúcar y otras presentaciones", Padre = 1 },
                    new Enumerado() { Valor = "Otros Productos Alimenticios", Padre = 1 },
                    new Enumerado() { Valor = "Café, Te y Cacao", Padre = 1 },
                    new Enumerado() { Valor = "Aguas Minerales, Refrescos, Jugos de Frutas", Padre = 1 },
                    new Enumerado() { Valor = "Bebidas Alcohólicas", Padre = 1 },
                    new Enumerado() { Valor = "Tabaco", Padre = 1 },
                    new Enumerado() { Valor = "Prendas de Vestir", Padre = 1 },
                    new Enumerado() { Valor = "Calzado", Padre = 1 },
                    new Enumerado() { Valor = "Artículos para el Hogar", Padre = 1 },
                    new Enumerado() { Valor = "Farmacéuticos", Padre = 1 },
                    new Enumerado() { Valor = "Cuidado Personal", Padre = 1 }






                    );
                context.Productos.AddRange(
                    new Producto()
                    {                       
                        Nombre = "LecheFresca",
                        CostoEstandar = 4.20m,
                        StockMinimo = 52,
                        Inventarios = new List<Inventario> { 
                        new Inventario() {
                        Stock =4,
                        AreaId = 2
                        }
                        }                     
                    },
                     new Producto()
                     {
                         Nombre = "Queso",
                         CostoEstandar = 2.32m,
                         StockMinimo =24,
                         Inventarios = new List<Inventario> {
                         new Inventario()
                         {
                             Stock = 3,
                             AreaId = 2
                         },
                         new Inventario()
                         { 
                            Stock = 14
                         }
                     }
                     }               
                    );
                context.Proveedors.AddRange(
                    new Proveedor()
                    { 
                        RUC = "20393803747",
                        RazonSocial = "AGROPECUARIA CALICANTO S.R.L.",
                        Direccion = "JR. INDEPENDENCIA NRO. 101 UCAYALI - CORONEL PORTILLO - CALLERIA",
                        Email = "calicanto@gmail.com",
                        Telefono = "+51 920321222"
                    }
                    );
                context.Compras.AddRange(
                    new Compra()
                    {
                        NumeroReferencia = "CreadoSinPOST",
                        FechaCompra = DateTime.Now,
                        ProveedorId = 1,
                        CompraDetalles = new List<CompraDetalle>
                        {
                            new CompraDetalle()
                            {
                                ProductoId = 1, //LecheFresca                               
                                CostoActual = 4.50m,
                                CantidadOrdenada = 5,
                                CantidadRecibida = 3,
                                CantidadRetornada = 1                                                                
                            }
                        }
                    }
                    ) ;
                context.Areas.AddRange(
                    new Area() { NombreArea = "Almacen", Sucursal = "Central" },
                    new Area() { NombreArea = "Frontis", Sucursal = "Central" }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ya hay datos");
            }
        }
    }
}
