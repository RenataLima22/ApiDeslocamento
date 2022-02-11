using AppDeslocamento.Domain.Interfaces;
using AppDeslocamento.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Carros.Commands.CriarCarro
{
    public class CriarCarroCommand : IRequest<Carro>
    {

        public string Placa { get; private set; }

        public string Descricao { get; private set; }

    }

    public class CriarCarroCommandHandler : IRequestHandler<CriarCarroCommand, Carro>
    {
        private readonly IUnityOfWork _unityOfWork;


        public CriarCarroCommandHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public async Task<Carro> Handle(CriarCarroCommand request,
            CancellationToken cancellationToken)
        {

            var carroInserir = new Carro(
                request.Placa,
                request.Descricao);

            Console.WriteLine("Our total" + request.Placa);

            var repositoryCarro = _unityOfWork.GetRepository<Carro>();

            repositoryCarro.Add(carroInserir);

            await _unityOfWork.CommitAsync();

            return carroInserir;
        }
    }


}
