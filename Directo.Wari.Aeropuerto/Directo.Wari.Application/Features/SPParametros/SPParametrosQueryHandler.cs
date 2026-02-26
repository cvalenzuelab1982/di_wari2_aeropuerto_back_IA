using Directo.Wari.Application.Features.SPParametrosLista.Dtos;
using Directo.Wari.Application.Features.SPParametrosLista.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directo.Wari.Application.Features.SPParametros
{
    public class SPParametrosQueryHandler : IRequestHandler<SPParametrosQuery, ParametroListaDto?>
    {
        private readonly ISPParametrosRepository _repository;

        public SPParametrosQueryHandler(ISPParametrosRepository repository)
        {
            _repository = repository;
        }

        public async Task<ParametroListaDto?> Handle(SPParametrosQuery request, CancellationToken cancellationToken)
        {
            return await _repository.getParameterStringNull(request.Codigo);
        }
    }
}
