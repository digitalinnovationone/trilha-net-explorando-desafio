namespace DesafioProjetoHospedagem.Models
{
    public class Reservation
    {
        public List<Person> Guests { get; set; }
        public Suite Suite { get; set; }
        public int BookedDays { get; set; }

        public Reservation() { }

        public Reservation(int bookedDays)
        {
            BookedDays = bookedDays;
        }

        public void RegisterGuests(List<Person> guests)
        {
            
            if (guests.Count > Suite.Capacity)
                throw new Exception("Number of guests greater than the suite's capacity");
            Guests = guests;
        }

        public void RegisterSuite(Suite suite) => Suite = suite;

        public int GetQuantityOfGuests() => Guests.Count;

        public decimal CalculateDailyValue()
        {
            return BookedDays > 10
                ? SuiteDailyValue() * 0.9m
                : SuiteDailyValue();
        }

        private decimal SuiteDailyValue() => BookedDays * Suite.DailyValue;
    }
}