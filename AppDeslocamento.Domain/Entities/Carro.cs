using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public class Carro : BaseEntity
    {
        public Carro(string placa, string descricao)
        {
            Placa = placa;
            Descricao = descricao;
        }

        public string Placa { get; private set; }

        public string Descricao { get; private set; }

        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();
        private readonly List<Deslocamento> _deslocamentos = new();
    }
}
