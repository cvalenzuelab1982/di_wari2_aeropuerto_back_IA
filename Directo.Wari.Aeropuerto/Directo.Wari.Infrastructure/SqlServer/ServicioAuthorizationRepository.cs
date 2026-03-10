using Directo.Wari.Application.Common.Models;
using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using Directo.Wari.Application.Features.ServicioAuthorization.Interfaces;
using Directo.Wari.Infrastructure.Persistence.Constants;
using Directo.Wari.Infrastructure.Persistence.Helpers;
using Directo.Wari.Infrastructure.SqlServer.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Directo.Wari.Infrastructure.SqlServer
{
    public class ServicioAuthorizationRepository : SqlServerRepositoryBase, IServicioAuthorizationRepository
    {
        public ServicioAuthorizationRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<PaginatedList<ServicioWariResponseDto>> ListarServicios(ServicioWariRequestDto request)
        {
            var lista = new List<ServicioWariResponseDto>();
            await using var connection = CreateConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.ServicioAuthorization.LISTAR_SERVICIOS_WARI;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@Tipo", SqlDbType.Int, request.Tipo);
            SqlParameterHelper.AddParameter(command, "@Usuario", SqlDbType.VarChar, request.Usuario);
            SqlParameterHelper.AddParameter(command, "@Compania", SqlDbType.Int, request.Compania);
            SqlParameterHelper.AddParameter(command, "@SubCompania", SqlDbType.VarChar, request.SubCompania);
            SqlParameterHelper.AddParameter(command, "@OrigenAeropuerto", SqlDbType.Bit, request.OrigenAeropuerto);
            SqlParameterHelper.AddParameter(command, "@Van", SqlDbType.Bit, request.Van);
            SqlParameterHelper.AddParameter(command, "@FechaFiltro", SqlDbType.VarChar, request.Fecha);
            SqlParameterHelper.AddParameter(command, "@IdEstado", SqlDbType.Int, request.IdEstado);
            SqlParameterHelper.AddParameter(command, "@IdTipoMovil", SqlDbType.Int, request.IdTipoMovil);
            SqlParameterHelper.AddParameter(command, "@SearchValue", SqlDbType.VarChar, request.SearchValue); //N.Reserva, Cliente, pasajero 
            SqlParameterHelper.AddParameter(command, "@PageNumber", SqlDbType.Int, request.PageNumber);
            SqlParameterHelper.AddParameter(command, "@PageSize", SqlDbType.Int, request.PageSize);

            var recordsFiltered = command.Parameters.Add("@RecordsFiltered", SqlDbType.Int);
            recordsFiltered.Direction = ParameterDirection.Output;

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            while (await reader.ReadAsync())
            {
                lista.Add(Map_ServicioWariResponseDto(reader));
            }

            await reader.DisposeAsync();

            var totalRecordsFiltered = recordsFiltered.Value is int value ? value : 0;

            return new PaginatedList<ServicioWariResponseDto>(
                lista,
                totalRecordsFiltered,
                request.PageNumber,
                request.PageSize);
        }

        public async Task<List<ServicioWariResponseDto>> FiltroBusquedaServicio(FiltroBusquedaServicioRequestDto request)
        {
            var lista = new List<ServicioWariResponseDto>();
            await using var connection = CreateConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.ServicioAuthorization.LISTAR_SERVICIOS_FILTRO_WARI;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@Busqueda", SqlDbType.VarChar, request.Busqueda);
            SqlParameterHelper.AddParameter(command, "@Filtro", SqlDbType.Int, request.Filtro);

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            while (await reader.ReadAsync())
            {
                lista.Add(Map_ServicioWariResponseDto(reader));
            }

            return lista;
        }

        public async Task<ServicioFullWariResponseDto?> ObtenerServicio(int IdServicio)
        {
            ServicioFullWariResponseDto? servicio = null;

            await using var connection = CreateConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.ServicioAuthorization.OBTENER_SERVICIOS_WARI;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@IdServicio", SqlDbType.Int, IdServicio);

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            //OBTENER SERVICIO
            if (await reader.ReadAsync())
            {
                servicio = MapServicioFull(reader);
            }

            if (servicio == null) return null;


            //OBTENER DESTINOS
            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    servicio.Destinos.Add(MapDestinoFull(reader));
                }
            }


            //OBTENER CARSEAT
            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    servicio.CarSeat.Add(reader.GetNullableString("RangoEdad") ?? string.Empty);
                }
            }

            //OBTENER PEAJES
            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    servicio.Peajes.Add(MapPeajeFull(reader));
                }
            }

            return servicio;
        }

        public async Task<List<HistorialServicioWariResponseDto>> ObtenerServicioByIdCliente(int Idcliente)
        {
            var lista = new List<HistorialServicioWariResponseDto>();
            await using var connection = CreateConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = SPName.ServicioAuthorization.ServicioByCliente;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 120;

            SqlParameterHelper.AddParameter(command, "@IdCliente", SqlDbType.Int, Idcliente);
            SqlParameterHelper.AddParameter(command, "@I009_Estado", SqlDbType.Int, 0);

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(MapObtenerServicioByIdCliente(reader));
            }

            return lista;
        }

        private ServicioWariResponseDto Map_ServicioWariResponseDto(SqlDataReader reader)
        {
            return new ServicioWariResponseDto
            {
                IdServicio = reader.GetNullableInt("IdServicio"),
                IdConductor = reader.GetNullableString("IdConductor"),
                IdEstado = reader.GetNullableInt("IdEstado"),
                IdTipoServicio = reader.GetNullableInt("IdTipoServicio"),

                Origen = reader.GetNullableString("Origen"),
                Destino = reader.GetNullableString("Destino"),
                Cliente = reader.GetNullableString("Cliente"),
                Pasajero = reader.GetNullableString("Pasajero"),
                Empresa = reader.GetNullableString("Empresa"),

                HoraServicio = reader.GetNullableString("HoraServicio"),
                FechaServicio = reader.GetNullableString("FechaServicio"),

                TotalServicio = reader.GetNullableDecimal("TotalServicio"),

                HoraETA = reader.GetNullableString("HoraETA"),

                Retenido = reader.GetBoolOrFalse("Retenido"),
                Preasignado = reader.GetNullableString("Preasignado"),

                VIP = reader.GetBoolOrFalse("VIP"),
                Exigente = reader.GetBoolOrFalse("Exigente"),

                HoraLlegada = reader.GetNullableString("HoraLlegada"),
                HoraAsignado = reader.GetNullableString("HoraAsignado"),

                ZonaOrigenPeligrosa = reader.GetBoolOrFalse("ZonaOrigenPeligrosa"),

                AlertaTardanza = reader.GetNullableString("AlertaTardanza"),

                EstadoConductor = reader.GetNullableInt("Estadoconductor"),

                CarSeat = reader.GetNullableInt("CarSeat") == 1
            };
        }

        private ServicioFullWariResponseDto MapServicioFull(SqlDataReader reader)
        {
            return new ServicioFullWariResponseDto
            {
                // =========================
                // Cliente
                // =========================
                IdServicio = reader.GetNullableInt("IdServicio"),
                IdCliente = reader.GetNullableInt("IdCliente"),
                EstadoServicio = reader.GetNullableInt("EstadoServicio"),

                Preasignado = reader.GetNullableString("Preasignado"),
                Usuario = reader.GetNullableString("Usuario"),
                IdConductor = reader.GetNullableString("IdConductor"),

                NombreCliente = reader.GetNullableString("NombreCliente"),
                Celular = reader.GetNullableString("Celular"),

                IdEmpresa = reader.GetNullableInt("IdEmpresa"),
                NombreEmpresa = reader.GetNullableString("NombreEmpresa"),

                Vip = reader.GetBoolOrFalse("VIP"),
                Exigente = reader.GetBoolOrFalse("Exigente"),
                Cliente = !(reader.GetBoolOrFalse("VIP") || reader.GetBoolOrFalse("Exigente")),

                ObservacionCliente = reader.GetNullableString("ObservacionCliente"),

                // =========================
                // Configuración / Reserva
                // =========================
                Referencia = reader.GetNullableString("Referencia"),
                TipoMovil = reader.GetNullableInt("TipoMovil"),
                TipoPago = reader.GetNullableInt("TipoPago"),

                CantidadCarseat = reader.GetNullableInt("CantidadCarseat"),
                AnticipadoAlMomento = reader.GetNullableBool("anticipadoAlMomento"),
                IsBoletaFactura = reader.GetNullableString("IsBoletaFactura"),

                ModoReserva = reader.GetNullableInt("ModoReserva"),
                Promocion = reader.GetNullableString("Promocion"),
                IdPromocion = reader.GetNullableInt("IdPromocion"),

                Pasajero = reader.GetNullableString("Pasajero"),
                ObservacionReserva = reader.GetNullableString("ObservacionReserva"),
                MotivoAnulacion = reader.GetNullableString("MotivoAnulacion"),

                IdTipoServicio = reader.GetNullableInt("IdTipoServicio"),

                // =========================
                // Conductor / Movil
                // =========================
                NombreConductor = reader.GetNullableString("NombreConductor"),
                CelularConductor = reader.GetNullableString("CelularConductor"),
                EstadoMovil = reader.GetNullableString("EstadoMovil"),

                Codigo = reader.GetNullableString("Codigo"),
                Modelo = reader.GetNullableString("Modelo"),
                Placa = reader.GetNullableString("Placa"),
                Color = reader.GetNullableString("Color"),

                // =========================
                // Costos
                // =========================
                CentroCosto = reader.GetNullableString("CentroCosto"),
                IdCentroCosto = reader.GetNullableInt("IdCentroCosto"),

                Factura = reader.GetNullableInt("Factura"),
                Tiempo = reader.GetNullableInt("Tiempo"),

                ContactoHora = reader.GetNullableString("ContactoHora"),
                InicioHora = reader.GetNullableString("InicioHora"),
                LlegadaHora = reader.GetNullableString("LlegadaHora"),
                TerminoHora = reader.GetNullableString("TerminoHora"),

                ZonaOrigen = reader.GetNullableString("ZonaOrigen"),
                ZonaDestino = reader.GetNullableString("ZonaDestino"),

                Origen = reader.GetNullableString("Origen"),
                Destino = reader.GetNullableString("Destino"),

                Kilometros = reader.GetNullableDecimal("Kilometros") is decimal km ? (float?)km : null,
                FechaServicio = reader.GetNullableString("FechaServicio"),

                TotalPeaje = reader.GetNullableDecimal("TotalPeaje"),
                TotalEspera = reader.GetNullableDecimal("TotalEspera"),
                CarSeatTotal = reader.GetNullableDecimal("CarSeatTotal"),
                Descuento = reader.GetNullableDecimal("Descuento"),
                Abono = reader.GetNullableDecimal("Abono"),
                RecargoHorario = reader.GetNullableDecimal("RecargoHorario"),

                Efectivo = reader.GetNullableDecimal("Efectivo"),
                Tarjeta = reader.GetNullableDecimal("Tarjeta"),
                Vale = reader.GetNullableDecimal("Vale"),

                TotalServicio = reader.GetNullableDecimal("TotalServicio"),
                TotalTarifa = reader.GetNullableDecimal("TotalTarifa"),

                IsPorTiempo = reader.GetNullableBool("isPorTiempo"),
                Retenido = reader.GetNullableBool("Retenido"),
                I056_Compania = reader.GetNullableInt("I056_Compania"),

                EdadPasajeros = reader.GetNullableString("EdadPasajeros"),
                NumeroReferencia = reader.GetNullableString("NumeroReferencia"),

                TarifaPlana = reader.GetBoolOrFalse("TarifaPlana"),

                OrigenLatitud = reader.GetNullableDouble("OrigenLatitud"),
                OrigenLongitud = reader.GetNullableDouble("OrigenLongitud"),
                DestinoLatitud = reader.GetNullableDouble("DestinoLatitud"),
                DestinoLongitud = reader.GetNullableDouble("DestinoLongitud"),

                Ruc = reader.GetNullableString("Ruc"),
                RazonSocial = reader.GetNullableString("RazonSocial"),

                NumRef = reader.GetNullableString("NumRef"),
                UltimosDigTarjeta = reader.GetNullableString("UltimosDigTarjeta"),

                SerieComprobante = reader.GetNullableString("SerieComprobante"),
                NumeroComprobante = reader.GetNullableString("NumeroComprobante"),

                TotalComprobante = reader.GetDecimalOrDefault("TotalComprobante"),
                EstadoComprobante = reader.GetIntOrDefault("EstadoComprobante"),
                TipoComprobante = reader.GetIntOrDefault("TipoComprobante"),

                TerminoFecha = reader.GetNullableString("TerminoFecha"),
                TotalParqueo = reader.GetNullableDecimal("TotalParqueo"),

                NumeroVuelo = reader.GetNullableString("NumeroVuelo"),
                DireccionFiscal = reader.GetNullableString("direccionFiscal")
            };
        }

        private DestinoWariFullResponseDto MapDestinoFull(SqlDataReader reader)
        {
            return new DestinoWariFullResponseDto
            {
                IdDestino = reader.GetNullableInt("IdDestino"),
                Origen = reader.GetNullableString("Origen"),
                Destino = reader.GetNullableString("Destino"),
                ZonaOrigen = reader.GetNullableString("ZonaOrigen"),
                IdZonaOrigen = reader.GetNullableInt("IdZonaOrigen"),
                ZonaDestino = reader.GetNullableString("ZonaDestino"),
                Pasajero = reader.GetNullableString("Pasajero"),
                IdPasajero = reader.GetNullableInt("IdPasajero"),
                IdZonaDestino = reader.GetNullableInt("IdZonaDestino"),
                Tarifa = reader.GetNullableDecimal("Tarifa"),
                OrigenLatitud = reader.GetNullableDouble("OrigenLatitud"),
                OrigenLongitud = reader.GetNullableDouble("OrigenLongitud"),
                DestinoLatitud = reader.GetNullableDouble("DestinoLatitud"),
                DestinoLongitud = reader.GetNullableDouble("DestinoLongitud"),
                Kilometros = reader.GetNullableDouble("Kilometros") is double km ? (float?)km : null
            };
        }

        private PeajeWariFullResponseDto MapPeajeFull(SqlDataReader reader)
        {
            return new PeajeWariFullResponseDto
            {
                IdPeaje = reader.GetNullableInt("IdPeaje"),
                NombrePeaje = reader.GetNullableString("nombrepeaje"),
                Monto = reader.GetNullableDecimal("monto")
            };
        }

        private HistorialServicioWariResponseDto MapObtenerServicioByIdCliente(SqlDataReader reader)
        {
            return new HistorialServicioWariResponseDto
            {
                IdServicio = reader.GetInt32("IdServicio"),
                Estado = reader.GetNullableString("Estado"),
                FechaServicio = reader.GetNullableString("FechaServicio"),
                IdConductor = reader.GetNullableString("IdConductor"),
                IdMovil = reader.GetNullableString("IdMovil"),
                DirOrigen = reader.GetNullableString("DirOrigen"),
                DirDestino = reader.GetNullableString("DirDestino"),
                DirOrigenNumero = reader.GetNullableString("DirOrigenNumero"),
                DirDestinoNumero = reader.GetNullableString("DirDestinoNumero"),
                Referencia = reader.GetNullableString("Referencia"),
                ZOrigen = reader.GetNullableString("ZOrigen"),
                ZDestino = reader.GetNullableString("ZDestino"),
                OrigenLatitud = reader.GetNullableDouble("OrigenLatitud"),
                OrigenLongitud = reader.GetNullableDouble("OrigenLongitud"),
                DestinoLatitud = reader.GetNullableDouble("DestinoLatitud"),
                DestinoLongitud = reader.GetNullableDouble("DestinoLongitud"),
                TotalServicio = reader.GetNullableDecimal("TotalServicio"),
                TipoPago = reader.GetNullableString("TipoPago"),
            };
        }
    }
}
