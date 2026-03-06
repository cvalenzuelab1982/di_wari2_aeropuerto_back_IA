namespace Directo.Wari.Application.Features.ServicioAuthorization.Dtos
{
    public class HistorialServicioWariResponseDto
    {
        public int? IdServicio { get; set; }
        public string? Estado { get; set; }
        public string? FechaServicio { get; set; }
        public string? IdConductor { get; set; }
        public string? IdMovil { get; set; }
        public string? DirOrigen { get; set; }
        public string? DirDestino { get; set; }
        public string? DirOrigenNumero { get; set; }
        public string? DirDestinoNumero { get; set; }
        public string? Referencia { get; set; }
        public string? ZOrigen { get; set; }
        public string? ZDestino { get; set; }
        public double? OrigenLatitud { get; set; }
        public double? OrigenLongitud { get; set; }
        public double? DestinoLatitud { get; set; }
        public double? DestinoLongitud { get; set; }
        public decimal? TotalServicio { get; set; }
        public string? TipoPago { get; set; }
    }
}
