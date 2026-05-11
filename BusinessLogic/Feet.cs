namespace QMAPP.BusinessLogic
{
    public class Feet
    {
        internal double FeetValue { get; set; }

        public Feet(double FeetValue)
        {
            this.FeetValue = FeetValue;
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
            Feet other = (Feet) obj;
            // check 
            return this.FeetValue== other.FeetValue;
        }
    }
}
