using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExplorandoDesafio.Models
{
    public class Suite
    {  
        private int _capacidade;
        private decimal _valorDaDiaria;
        private bool _status;

        public Suite(int numQuarto, string tipoDeSuite, int capacidadeHospesdes, decimal valorDaDiaria, bool status)
        {
            NumeroQuarto = numQuarto;
            PadraoSuite = tipoDeSuite;
            Capacidade = capacidadeHospesdes;
            ValorDiaria = valorDaDiaria;
            Status = status;
        }
        public int NumeroQuarto { get; set; }
        public string PadraoSuite { get; set; }
        public int Capacidade
        {
            get => _capacidade; // Acessa o campo privado
            set
            {
                if (int.IsPositive(value))
                {
                    _capacidade = value;
                }
                else if(int.IsNegative(value))
                {
                    throw new ArgumentException("O campo 'Capacidade' não pode ser Nevativo.");
                }
                else
                {
                    throw new ArgumentException("O campo 'Capacidade' não pode ser vazio.");
                }
                 // Define o campo privado
            }
        }
        public decimal ValorDiaria 
        {
            get => _valorDaDiaria; // Acessa o campo privado
            set
            {
                if (decimal.IsPositive(value))
                {
                    _valorDaDiaria = value;
                }
                else if(decimal.IsNegative(value))
                {
                    throw new ArgumentException("O campo 'Capacidade' não pode ser Nevativo.");
                }
                else
                {
                    throw new ArgumentException("O campo 'Capacidade' não pode ser vazio.");
                }
                 // Define o campo privado
            }
        }
        public bool Status
        {
            get => _status;
            set => _status = value;
        }

        public static implicit operator int(Suite v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Suite(int v)
        {
            throw new NotImplementedException();
        }
    }
}