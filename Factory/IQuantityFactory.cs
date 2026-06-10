namespace QMAPP.Factory;

using QMAPP.DTOs;
using QMAPP.src;
public interface IQuantityFactory
{
    object CreateQuantity(QuantityDTO dto);
    object GetUnit(string measurementType, string unit);
}