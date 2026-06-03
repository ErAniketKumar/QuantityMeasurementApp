// namespace QMAPP.BusinessLogic;

// public static class LengthUnitExtension
// {
//     public static double ConversionFector(LengthUnit unit)
//     {
//         switch (unit)
//         {
//             case LengthUnit.FEET:
//                 return 1.0;
//             case LengthUnit.INCH:
//                 return 1.0 / 12.0;
//             case LengthUnit.YARDS:
//                 return 3.0;
//             case LengthUnit.CENTIMETER:
//                 return 1.0 / 30.48;
//             default:
//                 throw new ArgumentException("Invalid unit!");
//         }
//     }

//     public static double ConvertToBaseUnit(LengthUnit unit, double value)
//     {
//         return value * LengthUnitExtension.ConversionFector(unit);
//     }

//     public static double ConvertFromBaseUnit(LengthUnit unit, double baseValue)
//     {
//         return baseValue / LengthUnitExtension.ConversionFector(unit);
//     }
// }
