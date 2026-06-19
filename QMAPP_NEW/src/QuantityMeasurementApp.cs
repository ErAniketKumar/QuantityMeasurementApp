using QMAPP.src;
public class QuantityMeasurementApp
{
    public void UC10()
    {
        Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(1, LengthUnit.INCH);

        Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(12, LengthUnit.INCH);

        Console.WriteLine(q1.Equals(q2));

        var converted = q1.ConvertTo(LengthUnit.INCH);

        Console.WriteLine(converted.Value);

        var added = q1.Add(q2, LengthUnit.FEET);

        Console.WriteLine(added.Value);

        Quantity<WeightUnit> w1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);

        Quantity<WeightUnit> w2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

        Console.WriteLine(w1.Equals(w2));
    }

    public void UC11()
    {
        Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRES);

        Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(2000, VolumeUnit.MILLILITRES);

        System.Console.WriteLine(q1.Equals(q2));

        var converted = q2.ConvertTo(VolumeUnit.LITRES);
        System.Console.WriteLine(converted.Value);

        var added = q1.Add(q2, VolumeUnit.LITRES);

        System.Console.WriteLine(added.Value);
    }

    public void UC12()
    {

        Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(1, LengthUnit.YARDS);
        Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(18, LengthUnit.INCH);

        var substracted = q1.Sub(q2);
        System.Console.WriteLine(substracted.Value);

        Quantity<VolumeUnit> v1 = new Quantity<VolumeUnit>(3, VolumeUnit.LITRES);
        Quantity<VolumeUnit> v2 = new Quantity<VolumeUnit>(500, VolumeUnit.MILLILITRES);

        var divided = v1.Div(v2);

        System.Console.WriteLine(divided.Value);

    }

    public void UC13()
    {
        Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(1, LengthUnit.YARDS);
        Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(18, LengthUnit.INCH);

        var substracted = q1.Sub(q2);
        System.Console.WriteLine(substracted.Value);

        Quantity<VolumeUnit> v1 = new Quantity<VolumeUnit>(3, VolumeUnit.LITRES);
        Quantity<VolumeUnit> v2 = new Quantity<VolumeUnit>(500, VolumeUnit.MILLILITRES);

        var divided = v1.Div(v2);

        System.Console.WriteLine(divided.Value);
    }
    public void UC14()
    {
        var t1 =
        new Quantity<TemperatureUnit>(
            100,
            TemperatureUnit.CELSIUS
        );

        var t2 =
        new Quantity<TemperatureUnit>(
            212,
            TemperatureUnit.FAHRENHEIT
        );

        System.Console.WriteLine(t1.Equals(t2));

        var converted = t1.ConvertTo(TemperatureUnit.FAHRENHEIT);
        System.Console.WriteLine(converted.Value);

    }
    public void Run()
    {
        // UC10();
        // UC11();
        // UC12();
        // UC13();
        UC14();
    }
}