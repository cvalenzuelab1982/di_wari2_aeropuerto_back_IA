using Directo.Wari.Application.Features.SPParametrosLista.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.SPParametros
{
    public class SPParametrosQuery : IRequest<ParametroListaDto?>
    {
        public string Codigo { get; set; }

        public SPParametrosQuery(string codigo)
        {
            Codigo = codigo;
        }
    }
}
