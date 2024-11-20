using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExplorandoDesafio.Models
{
    public class Pessoa
    {
        private string _nome; // Campo privado para armazenar o nome
        private string _sobrenome; // Campo privado para armazenar o sobrenome

        public Pessoa(string nomeHospede, string sobrenomeHospede)
        {
            Nome = nomeHospede;
            Sobrenome = sobrenomeHospede;
        }

        public string Nome
        {
            get => _nome.ToUpper(); // Acessa o campo privado
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O campo 'Nome' não pode ser vazio ou apenas espaços.");
                }
                _nome = value; // Define o campo privado
            }
        }

        public string Sobrenome
        {
            get => _sobrenome.ToUpper(); // Acessa o campo privado
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O campo 'Sobrenome' não pode ser vazio ou apenas espaços.");
                }
                _sobrenome = value; // Define o campo privado
            }
        }

        public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
    }
}
