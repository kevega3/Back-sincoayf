using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Back_sincoayf.Models
{
    public class Vehiculos
    {
        [Key]

        [JsonPropertyName("VehiculoID")]
        public int? VehiculoID { get; set; }
        [JsonPropertyName("Tipo")]
        public string? Tipo { get; set; } = string.Empty;
        [JsonPropertyName("Modelo")]
        public string? Modelo { get; set; } = string.Empty;
        [JsonPropertyName("Color")]
        public string? Color { get; set; } = string.Empty;
        [JsonPropertyName("Kilometraje")]
        public int? Kilometraje { get; set; }
        [JsonPropertyName("Valor")]
        public decimal? Valor { get; set; }
        public decimal? ValorBD { get; set; }
        [JsonPropertyName("FechaRegistro")]
        public DateTime? FechaRegistro { get; set; }
        [JsonPropertyName("Estado")]
        public string? Estado { get; set; } = string.Empty;
        [JsonPropertyName("Imagen")]
        public string? Imagen { get; set; } = string.Empty;
        [JsonPropertyName("CarroID")]
        public int? CarroID { get; set; }
        [JsonPropertyName("Cilindraje")]
        public int? Cilindraje { get; set; }
        [JsonPropertyName("NumeroVelocidades")]
        public int? NumeroVelocidades { get; set; }
    }
}
