using System.Text.Json;
using System.Text.Json.Serialization;

namespace Back_sincoayf.Models
{


    public class ValorDecimalConverter : JsonConverter<Decimal>
    {
        public override Decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetDecimal();
        }

        public override void Write(Utf8JsonWriter writer, Decimal value, JsonSerializerOptions options)
        {
            // Escribe el valor como entero, quitando los decimales
            writer.WriteNumberValue(Math.Floor(value));
        }
    }

    public class ListaPrecios
    {
        public int id { get; set; }
        [JsonPropertyName("Modelo")]
        public string Modelo { get; set; } = string.Empty;
        [JsonPropertyName("Valor")]
        [JsonConverter(typeof(ValorDecimalConverter))]
        public Decimal Valor { get; set; }
    }
}
