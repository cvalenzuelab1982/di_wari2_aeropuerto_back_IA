using Directo.Wari.Application.Common.Models;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Dtos
{
    public class ServicioWariRequestDto : PaginatedParams
    {
        public string? SearchValue { get; set; }
        public int Tipo { get; set; }
        public string Usuario { get; set; } = null!;
        public int Compania { get; set; }
        public string SubCompania { get; set; } = null!;
        public bool OrigenAeropuerto { get; set; }
        public bool Van { get; set; }
        public string? Fecha { get; set; }
        public int? IdEstado { get; set; }
        public int? IdTipoMovil { get; set; }
    }
}
