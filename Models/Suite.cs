using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoHospedagem
{
    public class Pessoa
    {
        public Pessoa()
        {
        }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public string Nome
        {
            get; set;
        }
        public string Sobrenome
        {
            get; set;
        }
        public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
    }
}
