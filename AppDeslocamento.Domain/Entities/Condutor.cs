using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public class Condutor : BaseEntity
    {
        public Condutor(string nome, string email)
        {
            Nome = nome;

            Email = email;

        }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();
        private readonly List<Deslocamento> _deslocamentos = new();
    }
}
