using QMAPP.src;
public class QuantityMeasurementApp
{
    public void UC10()
    {
        Quantity<LengthUnit> q1 =
                    new Quantity<LengthUnit>(
                        1,
                        LengthUnit.INCH
                    );

        Quantity<LengthUnit> q2 =
            new Quantity<LengthUnit>(
                12,
                LengthUnit.INCH
            );

        Console.WriteLine(q1.Equals(q2));

        var converted =
            q1.ConvertTo(
                LengthUnit.INCH
            );

        Console.WriteLine(
            converted.Value
        );

        var added =
            q1.Add(
                q2,
                LengthUnit.FEET
            );

        Console.WriteLine(
            added.Value
        );

        Quantity<WeightUnit> w1 =
            new Quantity<WeightUnit>(
                1,
                WeightUnit.KILOGRAM
            );

        Quantity<WeightUnit> w2 =
            new Quantity<WeightUnit>(
                1000,
                WeightUnit.GRAM
            );

        Console.WriteLine(
            w1.Equals(w2)
        );
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
    public void Run()
    {
        // UC10();
        UC11();
    }
}