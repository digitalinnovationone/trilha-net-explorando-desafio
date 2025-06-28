using System.Text;
using DesafioProjetoHospedagem.Domain.Enums;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

var Guestes = new List<Person>
    {
        new Person(nome: "Hóspede 1"),
        new Person(nome: "Hóspede 2"),
        new Person(nome: "Hóspede 3"),
        new Person(nome: "Hóspede 4"),
        new Person(nome: "Hóspede 5"),
        new Person(nome: "Hóspede 6"),
        new Person(nome: "Hóspede 7"),
        new Person(nome: "Hóspede 8"),
        new Person(nome: "Hóspede 9"),
        new Person(nome: "Hóspede 10"),
        new Person(nome: "Hóspede 11"),
        new Person(nome: "Hóspede 12")
    };

Suite suite = new Suite(typeOfSuite: TypeOfSuite.Premium, capacity: 10, dailyValue: 30);

Reservation reservation = new Reservation(11);
reservation.RegisterSuite(suite);
reservation.RegisterGuests(Guestes);

Console.WriteLine($"Hóspedes: {reservation.GetQuantityOfGuests()}");
Console.WriteLine($"Valor diária: {reservation.CalculateDailyValue()}");