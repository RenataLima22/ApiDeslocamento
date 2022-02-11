using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string cpf)
        {
            Nome = nome;

            Cpf = cpf;
        }

        public string Nome { get; private set; }

        public string Cpf { get; private set; }

        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();
        private readonly List<Deslocamento> _deslocamentos = new();
    }
}
