using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.Cliente.Interfaces;
using Directo.Wari.Infrastructure.Persistence.Constants;
using Directo.Wari.Infrastructure.Persistence.Helpers;
using Directo.Wari.Infrastructure.SqlServer.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class ClienteRepository : SqlServerRepositoryBase, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<ClienteResponseDto?> Where(int id)
        {
            await using var connection = CreateConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.Cliente.CLIENTE_ID;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@id", SqlDbType.Int, id);

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            if (!await reader.ReadAsync())
            {
                return null;
            }

            return Map_Where(reader);
        }

        public async Task<List<BeanRutinaResponseDto>> ObtenerRutina(int idcliente, int idEmpresa)
        {
            var lista = new List<BeanRutinaResponseDto>();
            await using var connection = CreateConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.Cliente.RUTINA_CLIENTE_WEB_WARI;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@idcliente", SqlDbType.Int, idcliente);
            SqlParameterHelper.AddParameter(command, "@Idempresa", SqlDbType.Int, idEmpresa);
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(Map_ObtenerRutina(reader));
            }

            return lista;
        }

        private ClienteResponseDto Map_Where(SqlDataReader reader)
        {
            return new ClienteResponseDto
            {
                IdCliente = reader.GetNullableInt("IdCliente"),
                IdEmpresa = reader.GetNullableInt("IdEmpresa"),

                CreacionUsuario = reader.GetNullableString("Creacion_Usuario"),
                CreacionFecha = reader.GetNullableDateTime("Creacion_Fecha"),
                ModificoUsuario = reader.GetNullableString("Modifico_Usuario"),
                ModificoFecha = reader.GetNullableDateTime("Modifico_Fecha"),

                NombreCompleto = reader.GetNullableString("NombreCompleto"),
                Nombres = reader.GetNullableString("Nombres"),
                Paterno = reader.GetNullableString("Paterno"),
                Materno = reader.GetNullableString("Materno"),

                CentroCostoCodigo = reader.GetNullableString("CentroCosto_Codigo"),
                IdCentroCosto = reader.GetNullableInt("IdCentroCosto"),

                Activo = reader.GetNullableBool("Activo"),

                Email = reader.GetNullableString("Email"),
                Celular = reader.GetNullableString("Celular"),

                DocumentoIdentidad = reader.GetNullableString("DocumentoIdentidad"),
                DNI = reader.GetNullableString("DNI"),
                RUC = reader.GetNullableString("RUC"),

                RazonSocial = reader.GetNullableString("RazonSocial"),
                NombreEmpresa = reader.GetNullableString("NombreEmpresa"),

                Rol = reader.GetNullableInt("Rol"),
                NombreRol = reader.GetNullableString("NombreRol"),

                Vip = reader.GetNullableBool("Vip"),
                Exigente = reader.GetNullableBool("Exigente"),

                Birthday = reader.GetNullableDateTime("Birthday"),

                Direccion = reader.GetNullableString("Direccion"),
                Distrito = reader.GetNullableString("Distrito"),
                Referencia = reader.GetNullableString("Referencia"),

                Latitud = reader.GetNullableDouble("Latitud"),
                Longitud = reader.GetNullableDouble("Longitud"),

                Abono = reader.GetNullableDecimal("Abono"),
                PrepagoRecibido = reader.GetNullableDecimal("PrepagoRecibido"),
                PrepagoUsado = reader.GetNullableDecimal("PrepagoUsado"),
                PrepagoDisponible = reader.GetNullableDecimal("PrepagoDisponible"),

                Presupuesto = reader.GetNullableDecimal("Presupuesto"),
                FlagPresupuesto = reader.GetNullableBool("FlagPresupuesto"),
                EstadoPresupuesto = reader.GetNullableBool("EstadoPresupuesto"),

                Saldo = reader.GetNullableDecimal("saldo"),
                Consumo = reader.GetNullableDecimal("consumo"),

                TiempoReserva = reader.GetNullableInt("TiempoReserva"),

                ClienteObs = reader.GetNullableString("ClienteObs"),
                Adicional = reader.GetNullableString("Adicional"),
                Dias = reader.GetNullableString("Dias"),

                HoraInicioServicio = reader.GetNullableString("HoraInicioServicio"),
                HoraFinServicio = reader.GetNullableString("HoraFinServicio"),
                HoraInicioEspecialServicio = reader.GetNullableString("HoraInicioEspecialServicio"),
                HoraFinEspecialServicio = reader.GetNullableString("HoraFinEspecialServicio"),
                HoraExtendidoInicioServicio = reader.GetNullableString("HoraExtendidoInicioServicio"),
                HoraExtendidoFinServicio = reader.GetNullableString("HoraExtendidoFinServicio"),

                pDaily = reader.GetNullableDecimal("pDaily"),
                pWeekly = reader.GetNullableDecimal("pWeekly"),
                pMonthly = reader.GetNullableDecimal("pMonthly"),
                pYearly = reader.GetNullableDecimal("pYearly"),

                isDaily = reader.GetNullableBool("isDaily"),
                isWeekly = reader.GetNullableBool("isWeekly"),
                isMonthly = reader.GetNullableBool("isMonthly"),
                isYearly = reader.GetNullableBool("isYearly"),

                VerEmpresaAprobacion = reader.GetBoolOrFalse("VerEmpresaAprobacion"),

                IdAprobador = reader.GetIntOrDefault("IdAprobador"),
                RequiereAprobacion = reader.GetBoolOrFalse("RequiereAprovacion"),
                EmitirFactura = reader.GetBoolOrFalse("emitirFactura"),

                TiempoEstimadoEntrega = reader.GetDecimalOrDefault("tiempoEstimadoEntrega"),

                IsoCountryCheck = reader.GetBoolOrFalse("IsoCountryCheck"),
                ServicioRetorno = reader.GetBoolOrFalse("ServicioRetorno"),

                ComboAeropuerto = reader.GetNullableString("ComboAeropuerto"),

                FlagRecargo = reader.GetNullableBool("deshabilitarVisibilidadTarifa"),
                RecargoTarifa = reader.GetNullableDecimal("RecargoTarifa"),

                Area = reader.GetNullableString("Area"),

                IdArea = reader.GetIntOrDefault("idArea"),
                IdGrupoNegocio = reader.GetIntOrDefault("IdGrupoNegocio"),
                IdCCCodigo = reader.GetIntOrDefault("IdCC_Codigo"),

                IsTerminosAceptado = reader.GetBoolOrFalse("isTerminosAceptado")
            };
        }

        private BeanRutinaResponseDto Map_ObtenerRutina(SqlDataReader reader)
        {
            return new BeanRutinaResponseDto
            {
                IdRutina = reader.GetInt32("IdRutina"),
                Reserva = reader.GetInt32("Reserva"),
                DirDestino = reader.GetNullableString("DirDestino"),
                DirOrigen = reader.GetNullableString("DirOrigen"),
                Fecha = reader.GetNullableDateTime("Fecha"),
                Hora = reader.GetNullableString("Hora"),
                Operador = reader.GetNullableString("Operador"),
                ZonaDestino = reader.GetNullableString("ZonaDestino"),
                ZonaOrigen = reader.GetNullableString("ZonaOrigen"),
            };
        }
    }
}
