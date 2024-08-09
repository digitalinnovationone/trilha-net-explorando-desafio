using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Exception
{
    public class CapacidadeInvalidaException : ArgumentOutOfRangeException
    {
        public CapacidadeInvalidaException() { }
        public CapacidadeInvalidaException(string msg) : base(msg) { }
    }
}