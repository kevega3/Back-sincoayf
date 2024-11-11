using Back_sincoayf.Models;
using Back_sincoayf.VehiculoBDContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace Back_sincoayf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly VehiculosDbContext context;
        public UsuarioController(VehiculosDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Usuario([FromBody] Usuario login)
        {
            try
            {
                var email = login.Email;
                var password = login.Password;

                var result = await context.Usuarios.FromSqlRaw("exec buscarUsuarios @Email, @Password",
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Password", password)).ToListAsync();

                if (result == null || !result.Any()){
                    var response = new ApiResponse<List<Usuario>>
                    {
                        Error = false,
                        Ayuda = "Usuario o Contraseña incorrecta",
                        Data = []
                    };
                    return BadRequest(response);
                }
                else
                {
                    var response = new ApiResponse<List<Usuario>>
                    {
                        Error = false,
                        Ayuda = "LogeoExitoso",
                        Data = result
                    };
                    return Ok(response);
                }               
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<List<Usuario>>
                {
                    Error = true,
                    Ayuda = ex.Message,
                    Data = []
                };

                return BadRequest(response);
            }
        }

    }
}
