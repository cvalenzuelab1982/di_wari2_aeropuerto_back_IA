namespace Directo.Wari.Application.Features.EmpresaAuthorization.Dtos
{
    public class EmpresaResponseFullDto
    {
        public int? IdEmpresa { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public string? Atencion { get; set; }
        public string? Telefono1 { get; set; }
        public string? Telefono2 { get; set; }

        public byte? DiasCredito { get; set; }
        public int? IdZona { get; set; }
        public int? IdUbigeo { get; set; }

        public string? Direccion { get; set; }
        public string? DireccionNumero { get; set; }
        public string? Referencia { get; set; }

        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }

        public string? DireccionFactura { get; set; }
        public string? Email { get; set; }
        public string? Prefijo { get; set; }

        public bool? RequeridoCentroCosto { get; set; }
        public int? MovilFechaFabricacion { get; set; }
        public bool? MovilAireAcondicionado { get; set; }
        public bool? MovilMaleteraAmplia { get; set; }

        public bool? ValeElectronico { get; set; }
        public bool? ValeFisico { get; set; }
        public bool? PagoCredito { get; set; }
        public bool? Activo { get; set; }

        public int? Prioridad { get; set; }
        public string? Fonema { get; set; }

        public string? CreacionUsuario { get; set; }
        public DateTime? CreacionFecha { get; set; }
        public string? ModificoUsuario { get; set; }
        public DateTime? ModificoFecha { get; set; }

        public string? CodGrupo { get; set; }
        public int? TiempoReserva { get; set; }
        public bool? TiempoEspera { get; set; }
        public int? ConDeuda { get; set; }

        public string? Configuracion { get; set; }
        public string? Informativo { get; set; }

        public int? IdDistritoFactura { get; set; }

        public decimal? PrepagoRecibido { get; set; }
        public decimal? PrepagoUsado { get; set; }
        public decimal? PrepagoDisponible { get; set; }
        public decimal? Presupuesto { get; set; }

        public bool? FlagPresupuesto { get; set; }
        public int? BloqueoEmpresa { get; set; }

        public string? HoraInicioServicio { get; set; }
        public string? HoraFinServicio { get; set; }

        public bool? RequiereAprobacion { get; set; }
        public int? NrHoras { get; set; }
        public string? Dias { get; set; }

        public bool? EstadoPresupuesto { get; set; }
        public int? EditCC { get; set; }
        public DateTime? FechaCorte { get; set; }

        public string? Observacion { get; set; }

        public decimal Saldo { get; set; }
        public bool Hotel { get; set; }
        public bool NotaObligatoria { get; set; }

        public string? Pais { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? CodigoPostal { get; set; }
        public string? IsoCountryCode { get; set; }

        public bool IsoCountryCheck { get; set; }
        public bool NotificarSupervisores { get; set; }

        // Presupuesto
        public decimal? PDaily { get; set; }
        public decimal? PWeekly { get; set; }
        public decimal? PMonthly { get; set; }
        public decimal? PYearly { get; set; }

        public bool? IsDaily { get; set; }
        public bool? IsWeekly { get; set; }
        public bool? IsMonthly { get; set; }
        public bool? IsYearly { get; set; }

        public bool CorreoCompartirServicio { get; set; }
        public bool CorreoCancelacion { get; set; }
        public bool CorreoReservaSupervisor { get; set; }
        public bool CorreoReservaGenerada { get; set; }

        public decimal RecargoTarifa { get; set; }

        public bool DeshabilitarVisibilidadTarifa { get; set; }
        public bool HabilitarVisibilidadDescripcion { get; set; }
        public bool? HabilitarSede { get; set; }
    }
}
