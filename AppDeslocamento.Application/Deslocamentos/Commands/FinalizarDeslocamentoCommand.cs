using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Deslocamentos.Commands
{
    public class FinalizarDeslocamentoCommand : IRequest
    {
        public long DeslocamentoId { get; set; }
        public string Observacao { get; set; }
        public decimal QuilometragemFinal { get; set; }
    }
    public class FinalizarDeslocamentoCommandHandler : IRequestHandler<FinalizarDeslocamentoCommand>
    {
        private readonly IUnityOfWork _unitOfWork;

        public FinalizarDeslocamentoCommandHandler(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(FinalizarDeslocamentoCommand request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamento>();

            var deslocamento = await repositoryDeslocamento
               .FindBy(d => d.Id == request.DeslocamentoId)
               .FirstAsync(cancellationToken);

            deslocamento.FinalizarDeslocamento(request.Observacao, request.QuilometragemFinal);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
