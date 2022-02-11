using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Clientes.Commands.CadastrarCliente
{
    public class CadastrarClienteCommand : IRequest<Cliente>
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }
    }

    public class CadastrarClienteCommandHandler : IRequestHandler<CadastrarClienteCommand, Cliente>
    {
        private readonly IUnityOfWork _unityOfWork;


        public CadastrarClienteCommandHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<Cliente> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteInserir = new Cliente(
                request.Nome,
                request.Cpf);

            var repositoryCliente = _unityOfWork.GetRepository<Cliente>();

            repositoryCliente.Add(clienteInserir);

            await _unityOfWork.CommitAsync();

            return clienteInserir;
        }
    }
}
