namespace Directo.Wari.Application.Features.CentroCostoAuthorization.Dtos
{
    public class CentroCostoResponseDto
    {
        public int? IdCentroCosto { get; set; }
        public int? IdEmpresa { get; set; }

        public string? Codigo { get; set; }
        public string? CodigoArea { get; set; }

        public string? Descripcion { get; set; }
        public string? Descripcion2 { get; set; }

        public bool? ConLimite { get; set; }
        public bool? Activo { get; set; }

        public decimal? Limite { get; set; }

        public string? Dias { get; set; }

        public string? CreacionUsuario { get; set; }
        public DateTime? CreacionFecha { get; set; }

        public string? ModificoUsuario { get; set; }
        public DateTime? ModificoFecha { get; set; }

        public decimal? PrepagoRecibido { get; set; }
        public decimal? PrepagoUsado { get; set; }
        public decimal? PrepagoDisponible { get; set; }

        public decimal? Presupuesto { get; set; }
        public bool? FlagPresupuesto { get; set; }

        public string? PDias { get; set; }
        public bool? EstadoPresupuesto { get; set; }

        public int? EditCC { get; set; }

        // Empresa
        public string? NombreEmpresa { get; set; }
        public decimal? PresupuestoEmpresa { get; set; }
        public string? EPDias { get; set; }

        public decimal? Monto { get; set; }
        public decimal? Saldo { get; set; }

        // Nueva estructura presupuesto
        public decimal? PDaily { get; set; }
        public decimal? PWeekly { get; set; }
        public decimal? PMonthly { get; set; }
        public decimal? PYearly { get; set; }

        public bool? IsDaily { get; set; }
        public bool? IsWeekly { get; set; }
        public bool? IsMonthly { get; set; }
        public bool? IsYearly { get; set; }

        public string? VisibilidadDescripcion { get; set; }

        public int? IdArea { get; set; }
    }
}
