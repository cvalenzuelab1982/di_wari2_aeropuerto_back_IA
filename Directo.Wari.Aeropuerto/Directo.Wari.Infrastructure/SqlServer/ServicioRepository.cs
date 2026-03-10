using Directo.Wari.Application.Features.Servicio.Dtos;
using Directo.Wari.Application.Features.Servicio.Interfaces;
using Directo.Wari.Infrastructure.Persistence.Constants;
using Directo.Wari.Infrastructure.Persistence.Helpers;
using Directo.Wari.Infrastructure.SqlServer.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class ServicioRepository : SqlServerRepositoryBase, IServicioRepository
    {
        public ServicioRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<BeanAuditoriaWariResponseDto>> GetAuditoriaServicio(int IdServicio)
        {
            var lista = new List<BeanAuditoriaWariResponseDto>();
            await using var connection = CreateConnection();
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
