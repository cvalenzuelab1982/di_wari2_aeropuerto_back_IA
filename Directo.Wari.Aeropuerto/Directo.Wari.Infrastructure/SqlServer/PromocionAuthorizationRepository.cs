using Directo.Wari.Application.Features.PromocionAuthorization.Dtos;
using Directo.Wari.Application.Features.PromocionAuthorization.Interfaces;
using Directo.Wari.Infrastructure.Persistence.Constants;
using Directo.Wari.Infrastructure.Persistence.Helpers;
using Directo.Wari.Infrastructure.SqlServer.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class PromocionAuthorizationRepository : SqlServerRepositoryBase, IPromocionAuthorizationRepository
    {
        public PromocionAuthorizationRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<PromocionResponseDto?> ObtenerPromocionesPorCliente(int idEmpresa, int idCliente)
        {
            await using var connection = CreateConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.Promocion.API_WEB_WARI_PROMOCIONES_POR_CLIENTE;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@IdEmpresa", SqlDbType.Int, idEmpresa);
            SqlParameterHelper.AddParameter(command, "@IdCliente", SqlDbType.Int, idCliente);

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            if (!await reader.ReadAsync())
            {
                return null;
            }

            return Map_ObtenerPromocionesPorCliente(reader);
        }

        private PromocionResponseDto Map_ObtenerPromocionesPorCliente(SqlDataReader reader)
        {
            return new PromocionResponseDto
            {
                idPromocion = reader.GetNullableInt("idPromocion"),
                codigo = reader.GetNullableString("codigo"),
                nombre = reader.GetNullableString("nombre")
            };
        }
    }
}
