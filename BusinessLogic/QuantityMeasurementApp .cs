using QMAPP.BusinessLogic;
namespace QMAPP.BusinessLogic
{
    public class QuantityMeasurementApp
    {
        public QuantityMeasurementApp()
        {
           
        }

        Feet feet1 = new Feet(10.5);
        Feet feet2 = new Feet(10.9);
        Feet feet3 = new Feet(11);

        Feet feet4 = new Feet(10.5);
        public void QuantityMeasurment()
        {
            Console.WriteLine(feet1.Equals(feet4));
        }
    }
}
