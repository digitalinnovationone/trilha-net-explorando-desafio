using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ExplorandoDesafio.Models
{
    public class Reserva
    {
        private Suite _quarto;
        public Reserva(int diasDaReserva, Suite quarto)
        {
            DiasReservados = diasDaReserva;
            Suite = quarto;
            Hospedes = new List<Pessoa>();
        }
        public Reserva()
        {
            Hospedes = new List<Pessoa>();
        }
        public int DiasReservados { get; set; }
        public Suite Suite
        {
            get => _quarto; 
            set => _quarto = value;
        }
        public List<Pessoa> Hospedes { get; set; }
        public List<Pessoa> CadastrarHospesdes(List<Pessoa> hospedeList)
        {
            Hospedes.AddRange(hospedeList);
            Console.WriteLine("Hóspedes cadastrados com sucesso.");
            return Hospedes;
        }
        public void ReservandoQuarto(Dictionary<Suite,object> quartosDict)
        {
            bool statusAtual = (bool)quartosDict[_quarto];
            if (statusAtual)
            {
                quartosDict[_quarto] = false;
                Console.WriteLine($"Reserva feita com sucesso para a suíte número {_quarto.NumeroQuarto}.");
            }
            else
            {
                Console.WriteLine($"A suíte número {_quarto.NumeroQuarto} já está ocupada.");
            }
        }

        public decimal CalcularValorDiaria()
        {
            var total = Suite.ValorDiaria * DiasReservados;

            if (DiasReservados>=10)
            {
                decimal totalComDesconto = total - (total * 0.1m);
                return totalComDesconto;
            }
            else
            {
                return total;
            }
            
        }
    }
}