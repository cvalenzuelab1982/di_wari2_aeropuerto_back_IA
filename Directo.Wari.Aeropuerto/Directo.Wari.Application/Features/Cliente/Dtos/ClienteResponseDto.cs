namespace Directo.Wari.Application.Features.Cliente.Dtos
{
    /// <summary>
    /// Este response solo cuenta con propiedades acorde al SP. por el momento no se detecta el uso al 100% de las propiedades
    /// </summary>
    public class ClienteResponseDto
    {
        public int? IdCliente { get; set; }
        public int? IdEmpresa { get; set; }

        public string? CreacionUsuario { get; set; }
        public DateTime? CreacionFecha { get; set; }
        public string? ModificoUsuario { get; set; }
        public DateTime? ModificoFecha { get; set; }

        public string? NombreCompleto { get; set; }
        public string? Nombres { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }

        public string? CentroCostoCodigo { get; set; }
        public int? IdCentroCosto { get; set; }

        public bool? Activo { get; set; }

        public string? Email { get; set; }
        public string? Celular { get; set; }

        public string? DocumentoIdentidad { get; set; }
        public string? DNI { get; set; }

        public string? RUC { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreEmpresa { get; set; }

        public int? Rol { get; set; }
        public string? NombreRol { get; set; }

        public bool? Vip { get; set; }
        public bool? Exigente { get; set; }

        public DateTime? Birthday { get; set; }

        public string? Direccion { get; set; }
        public string? Distrito { get; set; }
        public string? Referencia { get; set; }

        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public decimal? Abono { get; set; }

        public decimal? PrepagoRecibido { get; set; }
        public decimal? PrepagoUsado { get; set; }
        public decimal? PrepagoDisponible { get; set; }

        public decimal? Presupuesto { get; set; }
        public bool? FlagPresupuesto { get; set; }
        public bool? EstadoPresupuesto { get; set; }

        public decimal? Saldo { get; set; }
        public decimal? Consumo { get; set; }

        public int? TiempoReserva { get; set; }

        public string? ClienteObs { get; set; }
        public string? Adicional { get; set; }
        public string? Dias { get; set; }

        public string? HoraInicioServicio { get; set; }
        public string? HoraFinServicio { get; set; }

        public string? HoraInicioEspecialServicio { get; set; }
        public string? HoraFinEspecialServicio { get; set; }

        public string? HoraExtendidoInicioServicio { get; set; }
        public string? HoraExtendidoFinServicio { get; set; }

        public decimal? pDaily { get; set; }
        public decimal? pWeekly { get; set; }
        public decimal? pMonthly { get; set; }
        public decimal? pYearly { get; set; }

        public bool? isDaily { get; set; }
        public bool? isWeekly { get; set; }
        public bool? isMonthly { get; set; }
        public bool? isYearly { get; set; }

        public bool VerEmpresaAprobacion { get; set; }
        public int IdAprobador { get; set; }
        public bool RequiereAprobacion { get; set; }

        public bool EmitirFactura { get; set; }
        public decimal TiempoEstimadoEntrega { get; set; }

        public bool IsoCountryCheck { get; set; }
        public bool ServicioRetorno { get; set; }

        public string? ComboAeropuerto { get; set; }

        public bool? FlagRecargo { get; set; }
        public decimal? RecargoTarifa { get; set; }

        public string? Area { get; set; }
        public int IdArea { get; set; }

        public int IdGrupoNegocio { get; set; }
        public int IdCCCodigo { get; set; }

        public bool IsTerminosAceptado { get; set; }
    }
}
