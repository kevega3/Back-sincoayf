using Back_sincoayf.Models;
using Back_sincoayf.VehiculoBDContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Back_sincoayf.Services
{
    public class ServicesVehiculo
    {
        private readonly VehiculosDbContext context;

        public ServicesVehiculo(VehiculosDbContext context)
        {
            this.context = context;
        }
        public async Task<ApiResponse<List<Vehiculos>>> CrearVehiculoAsync(Vehiculos vehiculo)
        {
            var valorBD = vehiculo.ValorBD ?? 0;
            var porcentaje = (85 * valorBD) / 100;

            if (vehiculo.Valor >= 250000000)
            {
                return new ApiResponse<List<Vehiculos>>
                {
                    Error = true,
                    Ayuda = "El valor no puede ser mayor a 250000000",
                    Data = new List<Vehiculos>()
                };
            }

            if (vehiculo.Estado == "Usado" && vehiculo.Valor < porcentaje)
            {
                return new ApiResponse<List<Vehiculos>>
                {
                    Error = true,
                    Ayuda = "El valor de la moto usada no puede ser menor al 85%.",
                    Data = new List<Vehiculos>()
                };
            }

            if (vehiculo.Tipo == "Moto" && vehiculo.Cilindraje > 400)
            {
                return new ApiResponse<List<Vehiculos>>
                {
                    Error = true,
                    Ayuda = "La moto tiene mayor cilindraje al permitido",
                    Data = new List<Vehiculos>()
                };
            }

           
            return new ApiResponse<List<Vehiculos>>
            {
                Error = false,
                Ayuda = "Validaciones Correctas",
                Data = []
            };
        }
    }
}
