


using System.Threading.Channels;
using AutoMapper;
using Humanizer;
using NodaTime;
using Refit;
using UnitConversion;


var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<Car, EngineDto>(); });
var mapper = configuration.CreateMapper();
Car person = new Car();
person.Engine = 3.5;
var personDto = mapper.Map<EngineDto>(person);
Console.WriteLine("Результат роботи AutoMapper");
Console.WriteLine(personDto.Engine);
Console.WriteLine("---------------------------");



//UnitConversion
var gToKg = new MassConverter("g", "kg");
double gValue = 1228;
double kgValue = gToKg.LeftToRight(gValue);

Console.WriteLine("Результат роботи UnitConversion");
Console.WriteLine(gValue + " g = " + kgValue + " kg");
Console.WriteLine("-------------------------------");


//Refit
var api = RestService.For<ICountryApi>("https://jsonplaceholder.typicode.com");

var countries = await api.GetCountries();
Console.WriteLine("Результат роботи refit");

Console.WriteLine(countries);



// NodaTime 

Instant now = SystemClock.Instance.GetCurrentInstant();

ZonedDateTime nowInIsoUtc = now.InUtc();

Duration duration = Duration.FromMinutes(3);

ZonedDateTime thenInIsoUtc = nowInIsoUtc + duration;

var london = DateTimeZoneProviders.Tzdb["Europe/London"];

var localDate = new LocalDateTime(2015, 2, 25, 0, 30, 00);
var before = london.AtStrictly(localDate);
Console.WriteLine("Результат роботи NodaTime");
Console.WriteLine(before);
Console.WriteLine("-------------------------------");

// Humanizer
Console.WriteLine("Результат роботи Humanizer");
Console.WriteLine("PascalCaseInputStringIsTurnedIntoSentence".Humanize());
Console.WriteLine("Underscored_input_String_is_turned_INTO_sentence".Humanize());
Console.WriteLine("Underscored_input_string_is_turned_into_sentence".Humanize());

public interface ICountryApi
{
    [Get("/posts/1")]
    Task<Object> GetCountries();

}



//AutoMapper
class Car
{
    private double engine;

    public double Engine
    {
        get => engine;
        set => engine = value;
    }
}

class EngineDto
{
    private double engine;

    public double Engine
    {
        get => engine;
        set => engine = value;
    }
}
