using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.EmpresaAuthorization.Dtos;
using Directo.Wari.Application.Features.EmpresaAuthorization.Interfaces;
using Directo.Wari.Infrastructure.Persistence.Constants;
using Directo.Wari.Infrastructure.Persistence.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class EmpresaAuthorizationRepository : IEmpresaAuthorizationRepository
    {
        private readonly string _connectionString;

        public EmpresaAuthorizationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer")!;
        }

        public async Task<List<EmpresaResponseSimpleDto>> All(ClienteResponseDto? cliente)
        {
            var lista = new List<EmpresaResponseSimpleDto>();
            await using var connection = new SqlConnection(_connectionString);
            await using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            if (cliente == null)
            {
                command.CommandText = SPName.EmpresaAuthorization.EMPRESA_ALL;
            }
            else
            {
                command.CommandText = SPName.EmpresaAuthorization.EMPRESA_ALL_ID_ROL;
                SqlParameterHelper.AddParameter(command, "@IDROL", SqlDbType.Int, cliente.Rol);
            }

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(Map(reader));
            }

            return lista;
        }

        public async Task<EmpresaResponseInformativoDto?> Get(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.EmpresaAuthorization.EMPRESA_ID;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@id", SqlDbType.Int, id);

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            if (!await reader.ReadAsync())
            {
                return null;
            }

            return Map_Get(reader);
        }

        private EmpresaResponseSimpleDto Map(SqlDataReader reader)
        {
            return new EmpresaResponseSimpleDto
            {
                IdEmpresa = reader.GetNullableInt("idEmpresa"),
                NombreComercial = reader.GetNullableString("nombreComercial"),
                RazonSocial = reader.GetNullableString("RazonSocial"),
            };
        }

        private EmpresaResponseInformativoDto Map_Get(SqlDataReader reader)
        {
            return new EmpresaResponseInformativoDto
            {
                Informativo = reader.GetNullableString("Informativo"),
                RazonSocial = reader.GetNullableString("RazonSocial")
            };
        }
    }
}
