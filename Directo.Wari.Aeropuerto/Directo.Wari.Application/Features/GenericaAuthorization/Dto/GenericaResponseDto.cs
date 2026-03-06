namespace Directo.Wari.Application.Features.GenericaAuthorization.Dto
{
    public class GenericaResponseDto
    {
        public string? IDENT_CAMPO { get; set; }
        public string? CODL_CAMPO { get; set; }
        public int? CODI_ORDEN { get; set; }
        public int? CANT_CAMPO { get; set; }
        public string? ISOCountryCode { get; set; }
        public string? IconoHtml { get; set; }
        public string? Grupo { get; set; }
        public enum Tipos
        {
            TipoPago = 8,
            TipoServicio = 11,
            ModoReserva = 4
        }
    }
}
