using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DesafioProjetoHospedagem.Models;

namespace Models
{
    public class Hotel
    {
        public Hotel()
        {
            Suites = new List<Suite>();
            Reservas = new List<Reserva>();
        }
        public List<Suite> Suites { get; set; }
        public List<Reserva> Reservas { get; set; }

        public Suite ProcuraSuitePorTipo(string tipo)
        {
            foreach (var suite in Suites)
            {
                if (suite.TipoSuite == tipo)
                {
                    return suite;
                }
            }
            return null;
        }
        public void AddReserva()
        {
            if(Suites.Count == 0)
            {
                System.Console.WriteLine("Não há suites no hotel.");
                Console.ReadLine();
                return;
            }
            Reserva reserva = new Reserva();
            string tipoSuite = "";
            int diasReservados = 0;

            System.Console.Write("Tipo de Suite : ");
            tipoSuite = Console.ReadLine();
            while ((reserva.Suite = ProcuraSuitePorTipo(tipoSuite))==null)
            {
                System.Console.WriteLine("O tipo não existe!");
                System.Console.Write("Tipo de Suite : ");
                tipoSuite = Console.ReadLine();
            }
            System.Console.Write("Dias Reservados : ");
            while (!int.TryParse(Console.ReadLine(), out diasReservados))
            {
                System.Console.WriteLine("VALOR INVÁLIDO!");
                System.Console.Write("Dias Reservados : ");
            }
            reserva.DiasReservados = diasReservados;
            reserva.CadastrarHospedes();

            Reservas.Add(reserva);
            System.Console.WriteLine("Reserva adicionada!");
        }
        public void AddSuite()
        {
            Suite suite = new Suite();
            System.Console.WriteLine("Nova Suite :\n");
            suite.RecebeSuite();
            Suites.Add(suite);
            System.Console.WriteLine("Suite adicionada!");
        }

        public void Mostrar()
        {
            System.Console.WriteLine("Reservas :");
            int i = 1, j = 1;
            foreach (var reserva in Reservas)
            {
                System.Console.WriteLine($"\n{i}a reserva :");
                reserva.MostrarReserva();
                i++;
            }
            
            System.Console.WriteLine("Suites :");
            foreach (var suite in Suites)
            {
                System.Console.WriteLine($"\n{j}a suite :");
                suite.MostrarSuite();
                j++;
            }
            Console.ReadLine();
        }
    
    }
}