using Back_sincoayf.Models;
using Back_sincoayf.VehiculoBDContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Back_sincoayf.Controllers
{
    [Route("api/[controller]")]
    public class VentasController : Controller
    {

        private readonly VehiculosDbContext context;
        public VentasController(VehiculosDbContext context)
        {
            this.context = context;
        }

        public static string FormatearFecha(string fechaString)
        {
            DateTime fecha;

            // Intentamos parsear con dos posibles formatos
            if (DateTime.TryParseExact(fechaString, new[] { "dd-MM-yyyy", "dd/MM/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                return fecha.ToString("yyyy-MM-dd") + " 00:00:00.000";
            }
            else
            {
                throw new FormatException("La fecha no tiene un formato válido.");
            }
        }


        //[Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> get()
        {
            try
            {
                var result = await context
                  .Set<Reporte>()
                  .FromSqlRaw("exec getVentas")
                  .ToListAsync();

                var respuesta = new ApiResponse<List<Reporte>>
                {
                    Error = false,
                    Ayuda = "Precios Encontrados",
                    Data = result
                };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<List<Reporte>>
                {
                    Error = true,
                    Ayuda = ex.Message,
                    Data = new List<Reporte>()
                };

                return BadRequest(response);
            }
        }



     

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> Agregar([FromBody] VentaComprador ventaComprador)
        {
            try
            {

                if (!string.IsNullOrEmpty(ventaComprador.FechaNacimiento))
                {
                    ventaComprador.FechaNacimiento = FormatearFecha(ventaComprador.FechaNacimiento);
                    var parameters = new[]
                      {
                    new SqlParameter("nombre", ventaComprador.Nombre),
                    new SqlParameter("idVehiculo", ventaComprador.IdVehiculo),
                    new SqlParameter("TipoDocumentoIdentidad", ventaComprador.TipoDocumentoIdentidad),
                    new SqlParameter("DocumentoIdentidad", ventaComprador.DocumentoIdentidad),
                    new SqlParameter("Telefono", ventaComprador.Telefono),
                    new SqlParameter("Email", ventaComprador.Email),
                    new SqlParameter("Direccion", ventaComprador.Direccion),
                    new SqlParameter("FechaNacimiento", ventaComprador.FechaNacimiento),
                };

                    await context.Database.ExecuteSqlRawAsync("exec agregarVenta @nombre, @idVehiculo , @TipoDocumentoIdentidad , @DocumentoIdentidad  , @Telefono , @Email , @Direccion  , @FechaNacimiento", parameters);

                    var response = new ApiResponse<VentaComprador>
                    {
                        Error = false,
                        Ayuda = "Se vendio exitosamente el vehiculo",
                        Data = ventaComprador
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest("La fecha de nacimiento es requerida en un formato especifico");
                }


            }
            catch (Exception ex)
            {
                var response = new ApiResponse<List<VentaComprador>>
                {
                    Error = true,
                    Ayuda = ex.Message,
                    Data = new List<VentaComprador>()
                };
                return BadRequest(response);
            }
        }
    }
}
