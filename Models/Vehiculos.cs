using System.ComponentModel.DataAnnotations;

namespace Back_sincoayf.Models
{
    public class Vehiculos
    {
        [Key]
        public int? VehiculoID { get; set; }  
        public string? Tipo { get; set; } = string.Empty;
        public string? Modelo { get; set; } = string.Empty;
        public string? Color { get; set; } = string.Empty;
        public int? Kilometraje { get; set; } 
        public decimal? Valor { get; set; }
        public decimal? ValorBD { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? Estado { get; set; } = string.Empty;
        public string? Imagen { get; set; } = string.Empty;
        public int? CarroID { get; set; } 
        public int? Cilindraje { get; set; } 
        public int? NumeroVelocidades { get; set; }
    }
}
