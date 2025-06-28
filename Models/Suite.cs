using DesafioProjetoHospedagem.Domain.Enums;

namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(TypeOfSuite typeOfSuite, int capacity, decimal dailyValue)
        {
            TypeOfSuite = typeOfSuite;
            Capacity = capacity;
            DailyValue = dailyValue;
        }

        public TypeOfSuite TypeOfSuite { get; set; }
        public int Capacity { get; set; }
        public decimal DailyValue { get; set; }
    }
}