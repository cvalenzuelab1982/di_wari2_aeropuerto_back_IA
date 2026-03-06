namespace Directo.Wari.Application.Features.Cliente.Dtos
{
    public class BeanRutinaResponseDto
    {
        public int IdRutina { get; set; }
        public int Reserva { get; set; }
        public string? Operador { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Hora { get; set; }
        public string? DirOrigen { get; set; }
        public string? ZonaOrigen { get; set; }
        public string? DirDestino { get; set; }
        public string? ZonaDestino { get; set; }
    }
}
