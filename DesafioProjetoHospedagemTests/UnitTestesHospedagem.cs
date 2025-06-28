using Xunit;
using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagem.Domain.Enums;
using System.Collections.Generic;

namespace DesafioProjetoHospedagemTests;

public class UnitTestesHospedagem
{
    [Fact]
    public void RegisterGuests_ShouldSetGuestsList()
    {
        var guests = new List<Person> { new Person("Teste 1"), new Person("Teste 2") };
        var reservation = new Reservation(2);
        var suite = new Suite(TypeOfSuite.Premium, 2, 100);
        reservation.Suite = suite;
        reservation.RegisterGuests(guests);

        Assert.Equal(2, reservation.GetQuantityOfGuests());
    }

    [Fact]
    public void RegisterSuite_ShouldSetSuite()
    {
        var suite = new Suite(TypeOfSuite.Premium, 2, 100);
        var reservation = new Reservation(2);

        reservation.RegisterSuite(suite);

        Assert.Equal(suite, reservation.Suite);
    }

    [Fact]
    public void CalculateDailyValue_ShouldReturnCorrectValue()
    {
        var suite = new Suite(TypeOfSuite.Premium, 2, 100);
        var reservation = new Reservation(2);
        reservation.RegisterSuite(suite);

        var value = reservation.CalculateDailyValue();

        Assert.Equal(200, value);
    }
}
