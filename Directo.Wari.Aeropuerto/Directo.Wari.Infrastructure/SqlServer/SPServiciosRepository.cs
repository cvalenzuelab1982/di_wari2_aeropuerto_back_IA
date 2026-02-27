using Directo.Wari.Application.Common.Models;
using Directo.Wari.Application.Features.SPServicios.Dtos;
using Directo.Wari.Application.Features.SPServicios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class SPServiciosRepository : ISPServiciosRepository
    {
        private readonly string _connectionString;

        public SPServiciosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer")!;
        }

        public async Task<PaginatedList<ServicioWariDto>> ListarServicios(RequestServicioWariDto request)
        {
            var lista = new List<ServicioWariDto>();
            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand("API_WEB_LISTAR_SERVICIOS_WARI_2_0_X4", connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(MapServicio(reader));
            }

            return new PaginatedList<ServicioWariDto>(
                lista,
                lista.Count,
                request.PageNumber,
                request.PageSize);
        }

        private ServicioWariDto MapServicio(SqlDataReader reader)
        {
            return new ServicioWariDto
            {
                IdServicio = reader["IdServicio"] as int?,
                IdConductor = reader["IdConductor"]?.ToString(),
                IdEstado = reader["IdEstado"] as int?,
                IdTipoServicio = reader["IdTipoServicio"] as int?,
                Origen = reader["Origen"]?.ToString(),
                Destino = reader["Destino"]?.ToString(),
                Cliente = reader["Cliente"]?.ToString(),
                Pasajero = reader["Pasajero"]?.ToString(),
                Empresa = reader["Empresa"]?.ToString(),
                HoraServicio = reader["HoraServicio"]?.ToString(),
                FechaServicio = reader["FechaServicio"]?.ToString(),
                TotalServicio = reader["TotalServicio"] as decimal?,
                HoraETA = reader["HoraETA"]?.ToString(),
                Retenido = reader["Retenido"] != DBNull.Value && (bool)reader["Retenido"],
                Preasignado = reader["Preasignado"]?.ToString(),
                VIP = reader["VIP"] != DBNull.Value && (bool)reader["VIP"],
                Exigente = reader["Exigente"] != DBNull.Value && (bool)reader["Exigente"],
                HoraLlegada = reader["HoraLlegada"]?.ToString(),
                HoraAsignado = reader["HoraAsignado"]?.ToString(),
                ZonaOrigenPeligrosa = reader["ZonaOrigenPeligrosa"] != DBNull.Value && (bool)reader["ZonaOrigenPeligrosa"],
                AlertaTardanza = reader["AlertaTardanza"]?.ToString(),
                EstadoConductor = reader["Estadoconductor"] as int?,
                CarSeat = reader["CarSeat"] != DBNull.Value && (bool)reader["CarSeat"]
            };
        }
    }
}
