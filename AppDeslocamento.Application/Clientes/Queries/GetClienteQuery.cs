using AppDeslocamento.Application.Clientes.Queries;
using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Clientes.Queries
{
    public class GetClienteQuery : IRequest<Cliente>
    {
        public long ClienteId { get; set; }
    }

    public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, Cliente>
    {
        private readonly IUnityOfWork _unitOfWork;

        public GetClienteQueryHandler(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            var repositoryCliente = _unitOfWork.GetRepository<Cliente>();

            var cliente = await repositoryCliente
                .FindBy(d => d.Id == request.ClienteId)
                .FirstAsync(cancellationToken);

            return cliente;
        }
    }
}
