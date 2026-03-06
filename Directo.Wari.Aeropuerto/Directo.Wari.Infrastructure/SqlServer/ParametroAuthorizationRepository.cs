using Directo.Wari.Application.Features.Parametro.Dtos;
using Directo.Wari.Application.Features.Parametro.Interfaces;
using Directo.Wari.Infrastructure.Persistence.Constants;
using Directo.Wari.Infrastructure.Persistence.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class ParametroAuthorizationRepository : IParametroAuthorizationRepository
    {
        private readonly string _connectionString;

        public ParametroAuthorizationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer")!;
        }

        public async Task<ParametroResponseDto?> GetParametro(string id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.ParametroAuthorization.PARAMETRO_GET_PARAMETRO_ID;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@ID", SqlDbType.VarChar, id);
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return Map(reader);    
            }

            return null;
        }

        private ParametroResponseDto Map(SqlDataReader reader)
        {
            return new ParametroResponseDto
            {
                nombre = reader.GetString("nombre"),
                valor = reader.GetString("valor"),
            };
        }
    }
}
