using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
        }

        // Cadastrar hóspedes na reserva
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a suíte foi cadastrada
            if (Suite == null)
            {
                throw new Exception("É necessário cadastrar uma suíte antes de adicionar hóspedes.");
            }

            // Verifica se a quantidade de hóspedes não ultrapassa a capacidade da suíte
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Número de hóspedes excede a capacidade da suíte.");
            }
        }

        // Cadastrar a suíte da reserva
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        // Retorna a quantidade de hóspedes
        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        // Calcula o valor total da diária
        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
                return 0;

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% para reservas de 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.9m;
            }

            return valor;
        }
    }
}
