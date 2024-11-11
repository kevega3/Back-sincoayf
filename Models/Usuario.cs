using System.ComponentModel.DataAnnotations;

namespace Back_sincoayf.Models
{
    public class Usuario
    {

        public required string Email { get; set; } 
        public required string Password { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        
    }
}
