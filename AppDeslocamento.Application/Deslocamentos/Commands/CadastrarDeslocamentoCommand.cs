using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Deslocamentos.Commands
{
    public class CadastrarDeslocamentoCommand : IRequest<Deslocamento>
    {
        public long CarroId { get; set; }
        public long ClienteId { get; set; }
        public long CondutorId { get; set; }
        public decimal QuilometragemInicial { get; set; }
    }

    public class CadastrarDeslocamentoCommandHandler :
        IRequestHandler<CadastrarDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnityOfWork _unitOfWork;

        public CadastrarDeslocamentoCommandHandler(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(
            CadastrarDeslocamentoCommand request,
            CancellationToken cancellationToken)
        {
            var deslocamentoInserir = new Deslocamento(
                 request.CarroId,
                 request.ClienteId,
                 request.CondutorId,
                 request.QuilometragemInicial);

            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamento>();

            repositoryDeslocamento.Add(deslocamentoInserir);

            await _unitOfWork.CommitAsync();

            return deslocamentoInserir;
        }
    }
}
