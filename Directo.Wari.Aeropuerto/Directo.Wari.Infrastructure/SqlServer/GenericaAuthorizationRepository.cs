using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.GenericaAuthorization.Dto;
using Directo.Wari.Application.Features.GenericaAuthorization.Interface;
using Directo.Wari.Infrastructure.Persistence.Constants;
using Directo.Wari.Infrastructure.Persistence.Helpers;
using Directo.Wari.Infrastructure.SqlServer.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class GenericaAuthorizationRepository : SqlServerRepositoryBase, IGenericaAuthorizationRepository
    {
        public GenericaAuthorizationRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<GenericaResponseDto>> Get(GetRequestDto request, ClienteResponseDto? cliente)
        {
            var lista = new List<GenericaResponseDto>();
            await using var connection = CreateConnection();
            await using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            // ID = TipoPago
            if (request.id == 8 && cliente != null)
            {
                command.CommandText = SPName.GenericaAuthorization.GENERICA_GET_TIPO_PAGO_EMPRESA_CLIENTE;

                SqlParameterHelper.AddParameter(command, "@IdEmpresa", SqlDbType.Int, cliente.IdEmpresa);
                SqlParameterHelper.AddParameter(command, "@I007_Dispositivo", SqlDbType.Int, 4);
                SqlParameterHelper.AddParameter(command, "@IdCliente", SqlDbType.Int, cliente.IdCliente);
            }

            // ID = TipoServicio
            else if (request.id == 11 && cliente != null)
            {
                command.CommandText = SPName.GenericaAuthorization.GENERICA_GET_TIPO_SERVICIO;

                SqlParameterHelper.AddParameter(command, "@IdEmpresa", SqlDbType.Int, cliente.IdEmpresa);
                SqlParameterHelper.AddParameter(command, "@I007_Dispositivo", SqlDbType.Int, 4);
            }

            // ID = Estados
            else if (request.id == 10)
            {
                command.CommandText = SPName.GenericaAuthorization.GENERICA_GET_ALL_ESTADO;
            }

            else
            {
                command.CommandText = SPName.GenericaAuthorization.GENERICA_GET_ID_ALL;

                SqlParameterHelper.AddParameter(command, "@ID", SqlDbType.Int, request.id);
            }

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(Map(reader));
            }

            return lista;
        }

        private GenericaResponseDto Map(SqlDataReader reader)
        {
            return new GenericaResponseDto
            {
                IDENT_CAMPO = reader.GetNullableString("IDENT_CAMPO"),
                CODL_CAMPO = reader.GetNullableString("CODL_CAMPO"),
                CODI_ORDEN = reader.GetNullableInt("CODI_ORDEN"),
                CANT_CAMPO = reader.GetNullableInt("CANT_CAMPO"),
                ISOCountryCode = reader.GetNullableString("ISOCountryCode"),
                IconoHtml = reader.GetNullableString("IconoHtml") ?? "",
                Grupo = reader.GetNullableString("Grupo")
            };
        }
    }
}
