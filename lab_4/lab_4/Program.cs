using System.Reflection;

Console.WriteLine("--------------------Task 2 part 1--------------------");

Type carTypeForSecondTask = typeof(Car);

Console.WriteLine($"Full name: {carTypeForSecondTask.FullName}");
Console.WriteLine($"Base type: {carTypeForSecondTask.BaseType}");
Console.WriteLine($"Is abstract: {carTypeForSecondTask.IsAbstract}");
Console.WriteLine($"Is sealed: {carTypeForSecondTask.IsSealed}");

Console.WriteLine("--------------------Task 2 part 2--------------------");

TypeInfo carTypeInfoForSecondTask = carTypeForSecondTask.GetTypeInfo();

Console.WriteLine($"Is class: {carTypeInfoForSecondTask.IsClass}");
Console.WriteLine($"Is interface: {carTypeInfoForSecondTask.IsInterface}");
Console.WriteLine($"Is public: {carTypeInfoForSecondTask.IsPublic}");
Console.WriteLine($"Is nested: {carTypeInfoForSecondTask.IsNested}");

Console.WriteLine("-----------------------Task 3-----------------------");


Type carTypeForThirdTask = typeof(Car);

MemberInfo[] members = carTypeForThirdTask.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

foreach (MemberInfo member in members)
{
    Console.WriteLine(member.Name);
}

Console.WriteLine("-----------------------Task 4-----------------------");

Car carForFoutrhTask = new Car("Toyota", "Supra", 1998, false, 320);

Type carTypeForFourthTask = carForFoutrhTask.GetType();

FieldInfo[] fields = carTypeForFourthTask.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

foreach (FieldInfo field in fields)
{
    Console.WriteLine($"{field.Name}: {field.GetValue(carForFoutrhTask)}");
}

Console.WriteLine("-----------------------Task 5-----------------------");

Car carForFifthTask = new Car("Tesla", "Model S", 2022, true, 155);

Type carTypeForFifthTask = carForFifthTask.GetType();

MethodInfo method = carTypeForFifthTask.GetMethod("Drive");

method.Invoke(carForFifthTask, null);


//"-----------------------Task 1-----------------------"

public class Car
{
    protected internal string _brand;
    internal string _model;
    private int Year { get; set; }
    public bool IsElectric { get; private set; }
    protected double TopSpeed { get; set; }

    public Car(string brand, string model, int year, bool isElectric, double topSpeed)
    {
        _brand = brand;
        _model = model;
        Year = year;
        IsElectric = isElectric;
        TopSpeed = topSpeed;
    }

    public void Drive()
    {
        Console.WriteLine($"Driving the {_brand} {_model}");
    }

    public double CalculateAcceleration(double distance, double time)
    {
        return distance / (time * time);
    }

    private void ChangeTopSpeed(double newTopSpeed)
    {
        TopSpeed = newTopSpeed;
        Console.WriteLine($"Changed top speed to {TopSpeed} mph");
    }
}