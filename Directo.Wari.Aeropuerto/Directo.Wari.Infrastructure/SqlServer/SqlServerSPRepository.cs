using Directo.Wari.Application.Features.SPParametrosLista.Dtos;
using Directo.Wari.Application.Features.SPParametrosLista.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class SqlServerSPRepository : ISqlServerRepository
    {
        private readonly IConfiguration _configuration;

        public SqlServerSPRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ParametroListaDto?> getParameterStringNull(string key)
        {
            var connectionString =
               _configuration.GetConnectionString("SqlServer");

            using var connection =
                new SqlConnection(connectionString);

            using var command =
                new SqlCommand("ParametroListar", connection);

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.AddWithValue(
                "@Nombre_Parametro",
                key);

            await connection.OpenAsync();

            using var reader =
                await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new ParametroListaDto
                {
                    idParametro = reader.GetInt32(0),
                    Nombre_Parametro = reader.GetString(1),
                    valor_parametro = reader.GetInt32(2)
                };
            }

            return null;
        }
    }
}
