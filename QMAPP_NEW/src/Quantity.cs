namespace QMAPP.src;

public class Quantity<U> where U : IMeasurable
{
    private readonly double _value;
    private readonly U _unit;

    public Quantity(double value, U unit)
    {
        _value = value;
        _unit = unit;
    }
    public double Value => _value;

    public U Unit => _unit;

    private Quantity<U> Calculate(Quantity<U> other, U targetUnit, ArithmeticOperation operation)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        if (targetUnit == null)
            throw new ArgumentNullException(nameof(targetUnit));

        _unit.ValidateOperationSupport(operation);
        other._unit.ValidateOperationSupport(operation);

        double firstBase = this._unit.ConvertToBaseUnit(this._value);
        double secondBase = other._unit.ConvertToBaseUnit(other._value);
        double resultBase;

        switch (operation)
        {
            case ArithmeticOperation.ADD:
                resultBase = firstBase + secondBase;
                break;
            case ArithmeticOperation.SUB:
                resultBase = firstBase - secondBase;
                break;
            case ArithmeticOperation.DIV:
                resultBase = firstBase / secondBase;
                break;
            default:
                throw new ArgumentException("Invalid Operator");
        }

        double result = targetUnit.ConvertFromBaseUnit(resultBase);

        return new Quantity<U>(
            result,
            targetUnit
        );

    }


    public override bool Equals(object? obj)
    {
        if (obj is not Quantity<U> other)
            return false;

        double firstBase =
            _unit.ConvertToBaseUnit(_value);

        double secondBase =
            other._unit.ConvertToBaseUnit(other._value);

        return Math.Abs(firstBase - secondBase)
               < 0.0001;
    }

    public Quantity<U> ConvertTo(U targetUnit)
    {
        double baseValue =
            _unit.ConvertToBaseUnit(_value);

        double converted =
            targetUnit.ConvertFromBaseUnit(baseValue);

        return new Quantity<U>(
            converted,
            targetUnit
        );
    }

    public Quantity<U> Add(Quantity<U> other)
    {
        return Calculate(other, _unit, ArithmeticOperation.ADD);
    }

    public Quantity<U> Sub(Quantity<U> other)
    {
        return Calculate(other, _unit, ArithmeticOperation.SUB);
    }


    public Quantity<U> Div(Quantity<U> other)
    {
        return Calculate(other, _unit, ArithmeticOperation.DIV);
    }

    public Quantity<U> Add(Quantity<U> other, U targetUnit)
    {
        return Calculate(other, targetUnit, ArithmeticOperation.ADD);
    }


    // public override string ToString()
    // {
    //     return $"{_value} {_unit}";
    // }

    public override string ToString()
    {
        return $"{Value} {Unit}";
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(_value, _unit);
    }
}