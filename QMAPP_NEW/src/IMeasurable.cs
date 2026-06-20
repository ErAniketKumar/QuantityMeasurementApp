using QMAPP.src;
public interface IMeasurable
{
    double ConvertFromBaseUnit(double value);
    double ConvertToBaseUnit(double value);
    bool SupportsArithmetic();

    void ValidateOperationSupport(
        ArithmeticOperation operation
    );

}

