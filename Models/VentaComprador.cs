using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Back_sincoayf.Models
{
    public class VentaComprador
    {
        public string Nombre { get; set; } = string.Empty;
        public int IdVehiculo { get; set; }
        public string TipoDocumentoIdentidad { get; set; } = string.Empty;
        public string DocumentoIdentidad { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string FechaNacimiento { get; set; } = string.Empty;
    }
    [Keyless] 
    public class Reporte
    {
        [JsonPropertyName("SumasVentas")]
        public decimal SumasVentas { get; set; }
        [JsonPropertyName("cantidadVehiculos")]
        public int cantidadVehiculos { get; set; }
        [JsonPropertyName("Modelo")]
        public string Modelo { get; set; } = string.Empty;
        [JsonPropertyName("Tipo")]
        public string Tipo { get; set; } = string.Empty;

    }
    public class Venta
    {
        public int Id { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime FechaVenta { get; set; }
        
    }

    public class Comprador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string TipoDocumentoIdentidad { get; set; } = string.Empty;
        public string DocumentoIdentidad { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }

}
