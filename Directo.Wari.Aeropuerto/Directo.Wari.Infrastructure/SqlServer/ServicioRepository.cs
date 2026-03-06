using Directo.Wari.Application.Features.CentroCostoAuthorization.Dtos;
using Directo.Wari.Application.Features.Servicio.Dtos;
using Directo.Wari.Application.Features.Servicio.Interfaces;
using Directo.Wari.Infrastructure.Persistence.Constants;
using Directo.Wari.Infrastructure.Persistence.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly string _connectionString;

        public ServicioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LegacyConnection")!;
        }

        public async Task<List<BeanAuditoriaWariResponseDto>> GetAuditoriaServicio(int IdServicio)
        {
            var lista = new List<BeanAuditoriaWariResponseDto>();
            await using var connection = new SqlConnection(_connectionString);
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.Servicio.AUDITORIA_SERVICIOS_WEB_WARI;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@IdServicio", SqlDbType.Int, IdServicio);
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(Map(reader));
            }

            return lista;
        }

        private BeanAuditoriaWariResponseDto Map(SqlDataReader reader)
        {
            return new BeanAuditoriaWariResponseDto
            {
                Atributo = reader.GetNullableString("Atributo"),
                DatoAnterior = reader.GetNullableString("DatoAnterior"),
                DatoNuevo = reader.GetNullableString("DatoNuevo"),
                Fecha = reader.GetNullableString("Fecha"),
                Usuario = reader.GetNullableString("Usuario"),
            };
        }
    }
}
