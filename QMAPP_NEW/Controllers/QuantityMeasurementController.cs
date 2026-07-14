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

        try
        {
            var result = await _service.Compare(q1, q2);

            return Ok(new
            {
                Success = true,
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(
        [FromBody] QuantityOperationRequestDto request)
    {
        try
        {
            var result = await _service.Add(request.Quantity1, request.Quantity2);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("sub")]
    public async Task<IActionResult> Sub(
        [FromBody] QuantityOperationRequestDto request)
    {
        try
        {
            var result = await _service.Sub(request.Quantity1, request.Quantity2);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("div")]
    public async Task<IActionResult> Div(
        [FromBody] QuantityOperationRequestDto request)
    {
        try
        {
            var result = await _service.Div(request.Quantity1, request.Quantity2);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("convert")]
    public async Task<IActionResult> Convert(
        [FromBody] ConvertRequestDto request)
    {
        try
        {
            var result = await _service.Convert(request.Quantity, request.TargetUnit);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        var result =
            await _service.GetHistory();

        return Ok(result);
    }

    [HttpDelete("history")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteHistory()
    {
        await _service.DeleteHistory();

        return NoContent();
    }
}