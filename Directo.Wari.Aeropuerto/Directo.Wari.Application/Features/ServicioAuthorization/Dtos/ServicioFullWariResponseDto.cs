namespace Directo.Wari.Application.Features.ServicioAuthorization.Dtos
{
    public class ServicioFullWariResponseDto
    {
        // Cliente
        public int? IdServicio { get; set; }
        public int? IdCliente { get; set; }
        public int? EstadoServicio { get; set; }

        public string? Preasignado { get; set; }
        public string? Usuario { get; set; }
        public string? IdConductor { get; set; }

        public string? NombreCliente { get; set; }
        public string? Celular { get; set; }

        public int? IdEmpresa { get; set; }
        public string? NombreEmpresa { get; set; }

        public bool Vip { get; set; }
        public bool Exigente { get; set; }
        public bool Cliente { get; set; }

        public string? ObservacionCliente { get; set; }

        // Destinos
        public List<DestinoWariFullResponseDto> Destinos { get; set; } = new();

        public string? Referencia { get; set; }
        public int? TipoMovil { get; set; }
        public int? TipoPago { get; set; }

        // Adicionales
        public int? CantidadCarseat { get; set; }
        public bool? AnticipadoAlMomento { get; set; }
        public string? IsBoletaFactura { get; set; }

        public int? ModoReserva { get; set; }
        public string? Promocion { get; set; }
        public int? IdPromocion { get; set; }

        public string? Pasajero { get; set; }
        public string? ObservacionReserva { get; set; }
        public string? MotivoAnulacion { get; set; }

        public int? IdTipoServicio { get; set; }

        // Conductor
        public string? NombreConductor { get; set; }
        public string? CelularConductor { get; set; }
        public string? EstadoMovil { get; set; }

        public string? Codigo { get; set; }
        public string? Modelo { get; set; }
        public string? Placa { get; set; }
        public string? Color { get; set; }

        // Costos
        public string? CentroCosto { get; set; }
        public int? IdCentroCosto { get; set; }

        public int? Factura { get; set; }
        public int? Tiempo { get; set; }

        public string? ContactoHora { get; set; }
        public string? InicioHora { get; set; }
        public string? LlegadaHora { get; set; }
        public string? TerminoHora { get; set; }

        public string? ZonaOrigen { get; set; }
        public string? ZonaDestino { get; set; }

        public string? Origen { get; set; }
        public string? Destino { get; set; }

        public float? Kilometros { get; set; }
        public string? FechaServicio { get; set; }

        public decimal? TotalPeaje { get; set; }
        public decimal? TotalEspera { get; set; }
        public decimal? CarSeatTotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Abono { get; set; }
        public decimal? RecargoHorario { get; set; }

        public decimal? Efectivo { get; set; }
        public decimal? Tarjeta { get; set; }
        public decimal? Vale { get; set; }

        public decimal? TotalServicio { get; set; }
        public decimal? TotalTarifa { get; set; }

        public bool? IsPorTiempo { get; set; }
        public bool? Retenido { get; set; }
        public int? I056_Compania { get; set; }

        public string? EdadPasajeros { get; set; }
        public string? NumeroReferencia { get; set; }

        public bool TarifaPlana { get; set; }

        public double? OrigenLatitud { get; set; }
        public double? OrigenLongitud { get; set; }
        public double? DestinoLatitud { get; set; }
        public double? DestinoLongitud { get; set; }

        public List<string> CarSeat { get; set; } = new();

        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }

        public string? NumRef { get; set; }
        public string? UltimosDigTarjeta { get; set; }

        public string? SerieComprobante { get; set; }
        public string? NumeroComprobante { get; set; }

        public decimal TotalComprobante { get; set; }
        public int EstadoComprobante { get; set; }
        public int TipoComprobante { get; set; }

        public string? TerminoFecha { get; set; }
        public decimal? TotalParqueo { get; set; }

        public string? NumeroVuelo { get; set; }
        public string? DireccionFiscal { get; set; }

        public List<PeajeWariFullResponseDto> Peajes { get; set; } = new();
    }

    public class DestinoWariFullResponseDto
    {
        public int? IdDestino { get; set; }

        public string? Origen { get; set; }
        public string? Destino { get; set; }

        public string? ZonaOrigen { get; set; }
        public int? IdZonaOrigen { get; set; }

        public string? ZonaDestino { get; set; }
        public int? IdZonaDestino { get; set; }

        public string? Pasajero { get; set; }
        public int? IdPasajero { get; set; }

        public decimal? Tarifa { get; set; }

        public double? OrigenLatitud { get; set; }
        public double? OrigenLongitud { get; set; }

        public double? DestinoLatitud { get; set; }
        public double? DestinoLongitud { get; set; }

        public float? Kilometros { get; set; }
    }

    public class PeajeWariFullResponseDto
    {
        public int? IdPeaje { get; set; }
        public string? NombrePeaje { get; set; }
        public decimal? Monto { get; set; }
    }
}
