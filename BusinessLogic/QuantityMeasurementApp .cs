using QMAPP.BusinessLogic;
namespace QMAPP.BusinessLogic
{
    // length unit
    public enum LengthUnit
    {
        INCH,
        FEET,
        YARDS,
        CENTIMETER
    }

    public static class LengthUnitExtension
    {
        public static double ConversionFector(LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.FEET:
                    return 12.0;
                case LengthUnit.INCH:
                    return 1.0;
                case LengthUnit.YARDS:
                    return 36.0;
                case LengthUnit.CENTIMETER:
                    return 0.393701;
                default:
                    throw new ArgumentException("Invalid unit!");
            }
        }
    }

    public class QuantityLength
    {
        private readonly double value;
        public readonly LengthUnit unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            this.value = value;
            this.unit = unit;
        }

        public double ConvertToBaseUnit()
        {
            return this.value * LengthUnitExtension.ConversionFector(this.unit);
        }

        public override bool Equals(object? obj)
        {
            return obj is QuantityLength other &&
            Math.Abs(
               this.ConvertToBaseUnit() -
               other.ConvertToBaseUnit()
               ) < 0.0001;
        }
    }
}

public class QuantityMeasurementApp
{
    public QuantityMeasurementApp() { }

    public void HandleFeetEquality()
    {
        Console.WriteLine("Enter First Value in Feet");
        double input1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter 2nd Value in Feet");

        double input2 = double.Parse(Console.ReadLine());

        Feet feet1 = new Feet(input1);
        Feet feet2 = new Feet(input2);

        bool result = feet1.Equals(feet2);
        Console.WriteLine($"Equality Feet Result: {result}");
    }

    public void HandleInchEquality()
    {
        Console.WriteLine("Enter first input in Inches!");
        double input1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter 2nd input in Inches!");
        double input2 = double.Parse(Console.ReadLine());

        Inch inch1 = new Inch(input1);
        Inch inch2 = new Inch(input2);

        bool result = inch1.Equals(inch2);
        Console.WriteLine($"Equality Inch Result: {result}");
    }


    public void HandleGenericLengthEquality()
    {
        QuantityLength[] quantities = new QuantityLength[2];

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Enter value for measurement {i + 1}:");

            double value = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1. Inch");
            Console.WriteLine("2. Feet");
            System.Console.WriteLine("3. Yards");
            System.Console.WriteLine("4. Cemtemeters");

            int choice = int.Parse(Console.ReadLine());

            LengthUnit unit;

            switch (choice)
            {
                case 1:
                    unit = LengthUnit.INCH;
                    break;

                case 2:
                    unit = LengthUnit.FEET;
                    break;
                case 3:
                    unit = LengthUnit.YARDS;
                    break;
                case 4:
                    unit = LengthUnit.CENTIMETER;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }

            quantities[i] = new QuantityLength(value, unit);
        }

        bool result = quantities[0].Equals(quantities[1]);

        Console.WriteLine($"Result of Quantity Length Equality: {result}");
    }


    public void QuantityMeasurmentMainMethod()
    {
        //HandleFeetEquality();
        //HandleInchEquality();
        HandleGenericLengthEquality();
    }
}
