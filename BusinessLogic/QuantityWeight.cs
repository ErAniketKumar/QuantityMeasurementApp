// using QMAPP.BusinessLogic;

// public class QuantityWeight
// {
//     private double _value;
//     private WeightUnit _unit;
//     public QuantityWeight() { }

//     public QuantityWeight(double value, WeightUnit unit)
//     {
//         this._value = value;
//         this._unit = unit;
//     }

//     public override bool Equals(object? obj)
//     {
//         return obj is QuantityWeight other && (
//             Math.Abs(
//                 WeightUnitExtension.ConvertToBaseUnit(other._unit, other._value) -
//                 WeightUnitExtension.ConvertToBaseUnit(this._unit, this._value)
//                 ) < 0.0001
//         );
//     }
//     public void HandleWeightEquality()
//     {
//         System.Console.WriteLine("Enter value1: ");
//         double val1 = double.Parse(Console.ReadLine());
//         System.Console.WriteLine("Enter Value2");
//         double val2 = double.Parse(Console.ReadLine());

//         QuantityWeight q1 = new QuantityWeight(val1, WeightUnit.KILOGRAM);
//         QuantityWeight q2 = new QuantityWeight(val2, WeightUnit.KILOGRAM);

//         System.Console.WriteLine(q1.Equals(q2));
//     }

//     private double HandleConversionOfUnitSrcToTargetSolve(double val, WeightUnit unit, WeightUnit target)
//     {
//         double baseVal = WeightUnitExtension.ConvertToBaseUnit(unit, val);

//         double result = baseVal * WeightUnitExtension.ConversionFector(target);

//         return result;
//     }
//     public void HandleConversionOfUnitSrcToTarget()
//     {
//         System.Console.WriteLine("Enter value");
//         double val = double.Parse(Console.ReadLine());
//         double res = HandleConversionOfUnitSrcToTargetSolve(val, WeightUnit.GRAM, WeightUnit.KILOGRAM);
//         System.Console.WriteLine("value in target unit : " + res);
//     }


//     private double HandleAdditionAndReturnBaseSolve(double val1, WeightUnit unit1, double val2, WeightUnit unit2)
//     {
//         val1 = WeightUnitExtension.ConvertToBaseUnit(unit1, val1);
//         val2 = WeightUnitExtension.ConvertToBaseUnit(unit2, val2);

//         double result = WeightUnitExtension.ConvertFromBaseUnit(unit1, val1 + val2);

//         return result;
//     }
//     public void HandleAdditionConvertResultFirstOperantUnit()
//     {
//         System.Console.WriteLine("Enter value 1");
//         double val1 = double.Parse(Console.ReadLine());
//         System.Console.WriteLine("Enter value 2");
//         double val2 = double.Parse(Console.ReadLine());

//         double res = HandleAdditionAndReturnBaseSolve(val1, WeightUnit.KILOGRAM, val2, WeightUnit.GRAM);

//         System.Console.WriteLine("value after addition is : " + res);
//     }

// }