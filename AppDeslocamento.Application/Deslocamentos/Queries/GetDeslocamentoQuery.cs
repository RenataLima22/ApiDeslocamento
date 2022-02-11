using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Deslocamentos.Queries
{
    public class GetDeslocamentoQuery : IRequest<Deslocamento>
    {
        public long DeslocamentoId { get; set; }
    }

    public class GetDeslocamentoQueryHandler : IRequestHandler<GetDeslocamentoQuery, Deslocamento>
    {
        private readonly IUnityOfWork _unityOfWork;

        public GetDeslocamentoQueryHandler(IUnityOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(GetDeslocamentoQuery request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unityOfWork.GetRepository<Deslocamento>();

            var deslocamento = await repositoryDeslocamento
                .FindBy(d => d.Id == request.DeslocamentoId)
                .FirstAsync(cancellationToken);

            return deslocamento;
        }
    }
}
