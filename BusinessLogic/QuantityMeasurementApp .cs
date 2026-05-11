using QMAPP.BusinessLogic;
namespace QMAPP.BusinessLogic
{

    
    public class QuantityMeasurementApp
    {
        public QuantityMeasurementApp()
        {
           
        }

        public void InputFeetValueAndCheckEquality()
        {
            Console.WriteLine("Enter First Value in Feet");
            double input1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter 2nd Value in Feet");

            double input2 = double.Parse(Console.ReadLine());

            Feet feet1 = new Feet(input1);
            Feet feet2 = new Feet(input2);

            bool result = feet1.Equals(feet2);
            Console.WriteLine($"Equality Result: {result}");
        }
        public void QuantityMeasurmentMainMethod()
        {
            InputFeetValueAndCheckEquality();
        }
    }
}
