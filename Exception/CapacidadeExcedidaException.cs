using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Exception
{
    public class CapacidadeExcedidaException : IOException
    {
        public CapacidadeExcedidaException() { }
        public CapacidadeExcedidaException(string msg) : base(msg) { }
    }
}