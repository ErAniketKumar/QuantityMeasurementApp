using QMAPP.BusinessLogic;
namespace QMAPP.BusinessLogic
{


    public class Feet
    {
        private readonly double feetValue;

        public Feet(double feetValue)
        {
            this.feetValue = feetValue;
        }

        public override bool Equals(object? obj)
        {
            // null check
            if (obj == null)
                return false;

            // type check
            if (obj.GetType() != this.GetType())
                return false;

            // type cast
            Feet other = (Feet)obj;
            // check 
            return this.feetValue.Equals(other.feetValue);
        }


        public override int GetHashCode()
        {
            return feetValue.GetHashCode();
        }

        public double GetFeetValue()
        {
            return this.feetValue;
        }
    }


    public class Inch { 
        private readonly double inchValue;
        public Inch(double inchValue)
        {
            this.inchValue = inchValue;
        }

        public override bool Equals(object? obj)
        {

            return obj is Inch other &&
                other.inchValue == inchValue;
        }

        public override int GetHashCode()
        {
            return inchValue.GetHashCode();
        }


        public double GetInchValue()
        {
            return this.inchValue;
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

        public void QuantityMeasurmentMainMethod()
        {
            HandleFeetEquality();
            HandleInchEquality();
        }
    }
}
