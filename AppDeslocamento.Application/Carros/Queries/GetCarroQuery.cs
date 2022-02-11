using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Carros.Queries
{
    public class GetCarroQuery : IRequest<List<Carro>>
    {
    }

    public class GetCarroQueryHandler : 
        IRequestHandler<GetCarroQuery, List<Carro>>
    {
        private readonly IUnityOfWork _unitOfWork;

        public GetCarroQueryHandler(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Carro>> Handle(GetCarroQuery request, CancellationToken cancellationToken)
        {
            var repositoryCarro = _unitOfWork.GetRepository<Carro>();

            var carros = await repositoryCarro
                .GetAll()
                .ToListAsync(cancellationToken);

            return carros;
        }
    }
}
