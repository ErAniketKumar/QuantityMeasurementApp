// namespace QMAPP.BusinessLogic
// {

//     public class Feet
//     {
//         private readonly double feetValue;

//         public Feet(double feetValue)
//         {
//             this.feetValue = feetValue;
//         }

//         public override bool Equals(object? obj)
//         {
//             // null check
//             if (obj == null)
//                 return false;

//             // type check
//             if (obj.GetType() != this.GetType())
//                 return false;

//             // type cast
//             Feet other = (Feet)obj;
//             // check 
//             return this.feetValue.Equals(other.feetValue);
//         }


//         public override int GetHashCode()
//         {
//             return feetValue.GetHashCode();
//         }

//         public double GetFeetValue()
//         {
//             return this.feetValue;
//         }
//     }


//     public class Inch
//     {
//         private readonly double inchValue;
//         public Inch(double inchValue)
//         {
//             this.inchValue = inchValue;
//         }

//         public override bool Equals(object? obj)
//         {

//             return obj is Inch other &&
//                 other.inchValue == inchValue;
//         }

//         public override int GetHashCode()
//         {
//             return inchValue.GetHashCode();
//         }


//         public double GetInchValue()
//         {
//             return this.inchValue;
//         }
//     }
// }