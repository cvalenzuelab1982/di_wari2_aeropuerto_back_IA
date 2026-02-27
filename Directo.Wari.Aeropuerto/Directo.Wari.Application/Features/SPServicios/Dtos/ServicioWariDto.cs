namespace Directo.Wari.Application.Features.SPServicios.Dtos
{
    public class ServicioWariDto
    {
        public int? IdServicio { get; set; }

        public string? IdConductor { get; set; }

        public int? IdEstado { get; set; }

        public int? IdTipoServicio { get; set; }

        public string? Origen { get; set; }

        public string? Destino { get; set; }

        public string? Cliente { get; set; }

        public string? Pasajero { get; set; }

        public string? Empresa { get; set; }

        public string? HoraServicio { get; set; }

        public string? FechaServicio { get; set; }

        public decimal? TotalServicio { get; set; }

        public string? HoraETA { get; set; }

        public bool Retenido { get; set; }

        public string? Preasignado { get; set; }

        public bool VIP { get; set; }

        public bool Exigente { get; set; }

        public string? HoraLlegada { get; set; }

        public string? HoraAsignado { get; set; }

        public bool ZonaOrigenPeligrosa { get; set; }

        public string? AlertaTardanza { get; set; }

        public int? EstadoConductor { get; set; }

        public bool CarSeat { get; set; }

        public bool IsCliente => !(VIP || Exigente);
    }
}
