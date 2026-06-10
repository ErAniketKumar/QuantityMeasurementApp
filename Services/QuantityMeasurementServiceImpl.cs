using QMAPP.DTOs;
using QMAPP.Repositories;
using QMAPP.src;
using QMAPP.Factory;
using System.Diagnostics;

namespace QMAPP.Services;

public class QuantityMeasurementServiceImpl
    : IQuantityMeasurementService
{
    private readonly IQuantityMeasurementRepository _repository;

    private readonly IQuantityFactory _factory;


    public QuantityMeasurementServiceImpl(
        IQuantityMeasurementRepository repository, IQuantityFactory factory)
    {
        _repository = repository;
        _factory = factory;
    }

    public bool Compare(QuantityDTO q1, QuantityDTO q2)
    {
        // business logic here

        if (q1.MeasurementType != q1.MeasurementType)
        {
            System.Console.WriteLine("measurment type missmatched!");
            return false;
        }

        dynamic d1 = _factory.CreateQuantity(q1);

        dynamic d2 = _factory.CreateQuantity(q2);

        return d1.Equals(d2);
    }


    public object Convert(QuantityDTO dto, string targetUnit)
    {
        dynamic quantity = _factory.CreateQuantity(dto);

        dynamic unit = _factory.GetUnit(dto.MeasurementType, targetUnit);

        return quantity.ConvertTo(unit);
    }

    public object Add(QuantityDTO dto1, QuantityDTO dto2)
    {
        dynamic q1 = _factory.CreateQuantity(dto1);
        dynamic q2 = _factory.CreateQuantity(dto2);
        return q1.Add(q2);
    }

    public object Sub(QuantityDTO dto1, QuantityDTO dto2)
    {
        dynamic q1 = _factory.CreateQuantity(dto1);
        dynamic q2 = _factory.CreateQuantity(dto2);
        return q1.Sub(q2);
    }

    public object Div(QuantityDTO dto1, QuantityDTO dto2)
    {
        dynamic q1 = _factory.CreateQuantity(dto1);
        dynamic q2 = _factory.CreateQuantity(dto2);
        return q1.Div(q2);
    }


}