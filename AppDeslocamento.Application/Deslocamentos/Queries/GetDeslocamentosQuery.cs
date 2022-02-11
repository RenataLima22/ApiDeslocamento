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
    public class GetDeslocamentosQuery : IRequest<List<Deslocamento>>
    {
    }

    public class GetDeslocamentosQueryHandler :
        IRequestHandler<GetDeslocamentosQuery, List<Deslocamento>>
    {
        private readonly IUnityOfWork _unityOfWork;

        public GetDeslocamentosQueryHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Deslocamento>> Handle(
            GetDeslocamentosQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryDeslocamento =
                _unityOfWork.GetRepository<Deslocamento>();

            var deslocamentos = await repositoryDeslocamento
                .GetAll()
                .ToListAsync(cancellationToken);

            return deslocamentos;
        }
    }
}
