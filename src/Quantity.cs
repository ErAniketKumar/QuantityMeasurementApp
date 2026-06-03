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
        double firstBase =
            _unit.ConvertToBaseUnit(_value);

        double secondBase =
            other._unit.ConvertToBaseUnit(other._value);

        double sumBase =
            firstBase + secondBase;

        double result =
            _unit.ConvertFromBaseUnit(sumBase);

        return new Quantity<U>(
            result,
            _unit
        );
    }

    public Quantity<U> Sub(Quantity<U> other)
    {
        double firstBase = this._unit.ConvertToBaseUnit(this._value);
        double secondBase = other._unit.ConvertToBaseUnit(other._value);

        double sub = firstBase - secondBase;

        double result = _unit.ConvertFromBaseUnit(sub);

        return new Quantity<U>(
            result,
            _unit
        );
    }


    public Quantity<U> Div(Quantity<U> other)
    {
        double firstBase = this._unit.ConvertToBaseUnit(this._value);
        double secondBase = other._unit.ConvertToBaseUnit(other._value);

        double div = firstBase / secondBase;

        double result = _unit.ConvertFromBaseUnit(div);

        return new Quantity<U>(
            result,
            _unit
        );
    }

    public Quantity<U> Add(
        Quantity<U> other,
        U targetUnit
    )
    {
        double firstBase =
            _unit.ConvertToBaseUnit(_value);

        double secondBase =
            other._unit.ConvertToBaseUnit(other._value);

        double sumBase =
            firstBase + secondBase;

        double result =
            targetUnit.ConvertFromBaseUnit(sumBase);

        return new Quantity<U>(
            result,
            targetUnit
        );
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_value, _unit);
    }
}