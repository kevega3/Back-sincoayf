
using Back_sincoayf.Models;
using Back_sincoayf.Services;
using Back_sincoayf.VehiculoBDContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;



namespace Back_sincoayf.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly ServicesVehiculo servicesVehiculo;
        private readonly VehiculosDbContext context;


        public VehiculosController(ServicesVehiculo servicesVehiculo, VehiculosDbContext context)
        {
            this.servicesVehiculo = servicesVehiculo ?? throw new ArgumentNullException(nameof(servicesVehiculo));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await context.Vehiculos.FromSqlRaw("exec buscarVehiculos").ToListAsync();

                var respuesta = new ApiResponse<List<Vehiculos>>
                {
                    Error = false,
                    Ayuda = "Vehículos encontrados",
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

        [Route("[action]")]
        [HttpPost]



        public async Task<ActionResult> Crear([FromBody] Vehiculos vehiculo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await servicesVehiculo.CrearVehiculoAsync(vehiculo);
                if (response.Error)
                {
                    return BadRequest(response);
                }
                //var result = await context.Vehiculos.FromSqlRaw("exec crearVehiculo @tipo, @modelo,@cilindraje,@numeroVelocidades,@color,@kilometraje,@valor,@Imagen,@Estado",
                //       new SqlParameter("@tipo", vehiculo.Tipo),
                //       new SqlParameter("modelo", vehiculo.Modelo),
                //       new SqlParameter("cilindraje", vehiculo.Cilindraje),
                //       new SqlParameter("numeroVelocidades", vehiculo.NumeroVelocidades),
                //       new SqlParameter("color", vehiculo.Color),
                //       new SqlParameter("kilometraje", vehiculo.Kilometraje),
                //       new SqlParameter("valor", vehiculo.Valor),
                //       new SqlParameter("Imagen", vehiculo.Imagen),
                //       new SqlParameter("Estado", vehiculo.Estado)).ToListAsync();
                // FromSqlRaw nos funciona para consultar datos y los podamos mapear en alguna entidad
                // ExecuteSqlRawAsync es funcional cuando se ejecuta algun query que no se necesita mapear con alguna entidad
                var parameters = new[]
                  {
                    new SqlParameter("@tipo", vehiculo.Tipo),
                    new SqlParameter("modelo", vehiculo.Modelo),
                    new SqlParameter("cilindraje", vehiculo.Cilindraje),
                    new SqlParameter("numeroVelocidades", vehiculo.NumeroVelocidades),
                    new SqlParameter("color", vehiculo.Color),
                    new SqlParameter("kilometraje", vehiculo.Kilometraje),
                    new SqlParameter("valor", vehiculo.Valor),
                    new SqlParameter("Imagen", vehiculo.Imagen),
                    new SqlParameter("Estado", vehiculo.Estado)
                };

                await context.Database.ExecuteSqlRawAsync("exec crearVehiculo @tipo, @modelo, @cilindraje, @numeroVelocidades, @color, @kilometraje, @valor, @Imagen, @Estado", parameters);


                response.Ayuda = "Cargado con Exito";

                return Ok(response);

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



        [Route("[action]")]
        [HttpPost]

        public async Task<ActionResult> Editar([FromBody] Vehiculos vehiculo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await servicesVehiculo.CrearVehiculoAsync(vehiculo);
                if (response.Error)
                {
                    return BadRequest(response);
                }

                var parameters = new[]
                 {
                    new SqlParameter("tipo", vehiculo.Tipo),
                    new SqlParameter("modelo", vehiculo.Modelo),
                    new SqlParameter("cilindraje", vehiculo.Cilindraje),
                    new SqlParameter("numeroVelocidades", vehiculo.NumeroVelocidades),
                    new SqlParameter("color", vehiculo.Color),
                    new SqlParameter("kilometraje", vehiculo.Kilometraje),
                    new SqlParameter("valor", vehiculo.Valor),
                    new SqlParameter("Imagen", vehiculo.Imagen),
                    new SqlParameter("Estado", vehiculo.Estado),
                    new SqlParameter("idVehiculo", vehiculo.VehiculoID)
                };

                await context.Database.ExecuteSqlRawAsync("exec editarVehiculo @tipo, @modelo, @cilindraje, @numeroVelocidades, @color, @kilometraje, @valor, @Imagen, @Estado,@idVehiculo", parameters);


                response.Ayuda = "Se edito con Exito";

                return Ok(response);

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
