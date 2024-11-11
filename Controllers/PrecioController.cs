using Back_sincoayf.Models;
using Back_sincoayf.VehiculoBDContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_sincoayf.Controllers
{
    [Route("api/[controller]")]
    public class PrecioController : Controller
    {

        private readonly VehiculosDbContext context;
        public PrecioController(VehiculosDbContext context)
        {
            this.context = context;
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> listaPrecios()
        {
            try
            {
                var result = await context.ListaPrecios.FromSqlRaw("exec buscarListaPrecios").ToListAsync();

                var respuesta = new ApiResponse<List<ListaPrecios>>
                {
                    Error = false,
                    Ayuda = "Precios Encontrados",
                    Data = result
                };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<List<Vehiculos>>
                {
                    Error = true,
                    Ayuda = ex.Message,
                    Data = new List<Vehiculos>()
                };

                return BadRequest(response);
            }
        }


    }
}
