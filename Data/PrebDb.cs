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
                context.Productos.AddRange(
                    new Producto()
                    {                       
                        Nombre = "LecheFresca",
                        CostoEstandar = 4.20m,
                        Inventarios = new List<Inventario> { 
                        new Inventario() {
                        Stock =4
                        }
                        }                     
                    },
                     new Producto()
                     {
                         Nombre = "Queso",
                         CostoEstandar = 2.32m,
                         Inventarios = new List<Inventario> {
                         new Inventario()
                         {
                             Stock = 3
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
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ya hay datos");
            }
        }
    }
}
