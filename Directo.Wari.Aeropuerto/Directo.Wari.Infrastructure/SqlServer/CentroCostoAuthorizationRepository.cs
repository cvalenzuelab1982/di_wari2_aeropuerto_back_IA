using Directo.Wari.Application.Features.CentroCostoAuthorization.Dtos;
using Directo.Wari.Application.Features.CentroCostoAuthorization.Interfaces;
using Directo.Wari.Infrastructure.Persistence.Constants;
using Directo.Wari.Infrastructure.Persistence.Helpers;
using Directo.Wari.Infrastructure.SqlServer.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class CentroCostoAuthorizationRepository : SqlServerRepositoryBase, ICentroCostoAuthorizationRepository
    {
        public CentroCostoAuthorizationRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<CentroCostoResponseDto>> WhereEmpresa(int id)
        {
            var lista = new List<CentroCostoResponseDto>();
            await using var connection = CreateConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.CentroCostoAuthorization.CENTROCOSTO_EMPRESA;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@id", SqlDbType.Int, id);
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(Map(reader));
            }

            return lista;
        }

        private CentroCostoResponseDto Map(SqlDataReader reader)
        {
            return new CentroCostoResponseDto
            {
                IdCentroCosto = reader.GetNullableInt("IdCentroCosto"),
                IdEmpresa = reader.GetNullableInt("IdEmpresa"),
                Codigo = reader.GetNullableString("Codigo"),
                CodigoArea = reader.GetNullableString("CodigoArea"),
                Descripcion = reader.GetNullableString("Descripcion"),
                Descripcion2 = reader.GetNullableString("Descripcion2"),
                ConLimite = reader.GetNullableBool("ConLimite"),
                Activo = reader.GetNullableBool("Activo"),
                Limite = reader.GetNullableDecimal("Activo"),
                Dias = reader.GetNullableString("Dias"),
                CreacionUsuario = reader.GetNullableString("CreacionUsuario"),
                CreacionFecha = reader.GetNullableDateTime("CreacionFecha"),
                ModificoFecha = reader.GetNullableDateTime("ModificoFecha"),
                PrepagoRecibido = reader.GetNullableDecimal("PrepagoRecibido"),
                PrepagoUsado = reader.GetNullableDecimal("PrepagoUsado"),
                PrepagoDisponible = reader.GetNullableDecimal("PrepagoDisponible"),
                EstadoPresupuesto = reader.GetNullableBool("EstadoPresupuesto"),
                Presupuesto = reader.GetNullableDecimal("Presupuesto"),
                PDias = reader.GetNullableString("PDias"),
                EditCC = reader.GetNullableInt("EditCC"),
                IdArea = reader.GetNullableInt("IdArea"),
                Saldo = reader.GetNullableDecimal("Saldo"),
                NombreEmpresa = reader.GetNullableString("NombreEmpresa"),
                VisibilidadDescripcion = reader.GetNullableString("VisibilidadDescripcion")
            };
        }
    }
}
