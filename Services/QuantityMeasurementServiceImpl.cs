using QMAPP.DTOs;
using QMAPP.Repositories;
using QMAPP.Factory;

using QMAPP.Entities;

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


    private async Task SaveHistory(
     QuantityDTO q1,
     QuantityDTO q2,
     string operation,
     string result)
    {
        await _repository.SaveAsync(
            new QuantityMeasurementEntity
            {
                Value1 = q1.Value,
                Unit1 = q1.Unit,
                Value2 = q2.Value,
                Unit2 = q2.Unit,
                MeasurementType = q1.MeasurementType,
                Operation = operation,
                Result = result,
                CreatedAt = DateTime.Now
            });
    }

    private void SaveConversionHistory(
        QuantityDTO dto,
        string targetUnit,
        string result
    )
    {
        _repository.SaveAsync(
            new QuantityMeasurementEntity
            {
                Value1 = dto.Value,
                Unit1 = dto.Unit,

                Value2 = 0,
                Unit2 = targetUnit,

                MeasurementType = dto.MeasurementType,

                Operation = "CONVERT",

                Result = result,

                CreatedAt = DateTime.Now
            }
        );
    }



    public async Task<bool> Compare(
         QuantityDTO q1,
         QuantityDTO q2)
    {
        if (q1.MeasurementType !=
           q2.MeasurementType)
        {
            throw new ArgumentException(
                "Measurement types do not match");
        }

        dynamic d1 =
            _factory.CreateQuantity(q1);

        dynamic d2 =
            _factory.CreateQuantity(q2);

        bool result = d1.Equals(d2);

        await SaveHistory(
            q1,
            q2,
            "COMPARE",
            result.ToString());

        return result;
    }


    public async Task<object> Convert(QuantityDTO dto, string targetUnit)
    {
        dynamic quantity = _factory.CreateQuantity(dto);

        dynamic unit = _factory.GetUnit(dto.MeasurementType, targetUnit);

        var result = quantity.ConvertTo(unit);

        SaveConversionHistory(
           dto,
           targetUnit,
           result.ToString()
         );

        return result;
    }

    public async Task<object> Add(QuantityDTO dto1, QuantityDTO dto2)
    {
        dynamic q1 = _factory.CreateQuantity(dto1);
        dynamic q2 = _factory.CreateQuantity(dto2);
        var result = q1.Add(q2);
        SaveHistory(
            dto1,
            dto2,
            "ADD",
            result.ToString()
        );
        return result;
    }

    public async Task<object> Sub(QuantityDTO dto1, QuantityDTO dto2)
    {
        dynamic q1 = _factory.CreateQuantity(dto1);
        dynamic q2 = _factory.CreateQuantity(dto2);
        var result = q1.Sub(q2);
        SaveHistory(
            dto1,
            dto2,
            "SUB",
            result.ToString()
        );
        return result;
    }

    public async Task<object> Div(QuantityDTO dto1, QuantityDTO dto2)
    {
        dynamic q1 = _factory.CreateQuantity(dto1);
        dynamic q2 = _factory.CreateQuantity(dto2);
        var result = q1.Div(q2);

        SaveHistory(
            dto1,
            dto2,
            "DIV",
            result.ToString()
        );

        return result;
    }


    public async Task<List<QuantityMeasurementEntity>>
    GetHistory()
    {
        return await _repository.GetAll();
    }

    public async Task DeleteHistory()
    {
        await _repository.DeleteAll();
    }
}