using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Condutores.Queries
{
    public class GetCondutorQuery : IRequest<Condutor>
    {
        public long CondutorId { get; set; }
    }

    public class GetCondutorQueryHandler : IRequestHandler<GetCondutorQuery, Condutor>
    {
        private readonly IUnityOfWork _unitOfWork;

        public GetCondutorQueryHandler(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(GetCondutorQuery request, CancellationToken cancellationToken)
        {
            var repositoryCondutor = _unitOfWork.GetRepository<Condutor>();

            var condutor = await repositoryCondutor
                .FindBy(d => d.Id == request.CondutorId)
                .FirstAsync(cancellationToken);

            return condutor;
        }
    }
}
