using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QMAPP.DTOs;
using QMAPP.Services;

namespace QMAPP.Controllers;

[ApiController]
[Route("api/quantity")]
public class QuantityMeasurementController : ControllerBase
{
    private readonly IQuantityMeasurementService _service;

    public QuantityMeasurementController(
        IQuantityMeasurementService service)
    {
        _service = service;
    }

    [HttpPost("compare")]
    public async Task<IActionResult> Compare(
        [FromBody] CompareRequestDto request)
    {
        var q1 = new QuantityDTO
        {
            Value = request.Value1,
            Unit = request.Unit1,
            MeasurementType = request.MeasurementType
        };

        var q2 = new QuantityDTO
        {
            Value = request.Value2,
            Unit = request.Unit2,
            MeasurementType = request.MeasurementType
        };

        var result = await _service.Compare(q1, q2);

        return Ok(new
        {
            Success = true,
            Result = result
        });
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(
        [FromBody] QuantityOperationRequestDto request)
    {
        var result =
            await _service.Add(
                request.Quantity1,
                request.Quantity2);

        return Ok(result);
    }

    [HttpPost("sub")]
    public async Task<IActionResult> Sub(
        [FromBody] QuantityOperationRequestDto request)
    {
        var result =
            await _service.Sub(
                request.Quantity1,
                request.Quantity2);

        return Ok(result);
    }

    [HttpPost("div")]
    public async Task<IActionResult> Div(
        [FromBody] QuantityOperationRequestDto request)
    {
        var result =
            await _service.Div(
                request.Quantity1,
                request.Quantity2);

        return Ok(result);
    }

    [HttpPost("convert")]
    public async Task<IActionResult> Convert(
        [FromBody] ConvertRequestDto request)
    {
        var result =
            await _service.Convert(
                request.Quantity,
                request.TargetUnit);

        return Ok(result);
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        var result =
            await _service.GetHistory();

        return Ok(result);
    }

    [HttpDelete("history")]
    [Authorize]
    public async Task<IActionResult> DeleteHistory()
    {
        await _service.DeleteHistory();

        return NoContent();
    }
}