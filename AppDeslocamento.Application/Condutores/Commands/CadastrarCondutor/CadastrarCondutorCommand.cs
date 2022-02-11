using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Condutores.Commands.CadastrarCondutor
{
    public class CadastrarCondutorCommand : IRequest<Condutor>
    {
        public string Nome { get; private set; }

        public string Email { get; private set; }
    }

    public class CadastrarCondutorCommandHandler : IRequestHandler<CadastrarCondutorCommand, Condutor>
    {
        private readonly IUnityOfWork _unityOfWork;


        public CadastrarCondutorCommandHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<Condutor> Handle(CadastrarCondutorCommand request, CancellationToken cancellationToken)
        {
            var condutorInserir = new Condutor(
                request.Nome,
                request.Email);

            var repositoryCondutor = _unityOfWork.GetRepository<Condutor>();

            repositoryCondutor.Add(condutorInserir);

            await _unityOfWork.CommitAsync();

            return condutorInserir;
        }
    }
}
