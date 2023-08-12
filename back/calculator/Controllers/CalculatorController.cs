using Microsoft.AspNetCore.Mvc;

namespace calculator.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : Controller
{
    private Calculator _calculator;

    public CalculatorController(Calculator calculator)
    {
        _calculator = calculator;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Connected");
    }

    [HttpPost]
    public IActionResult Post([FromBody] CalcRequest request )
    {
        double result = 0;
        try
        {
            result = _calculator.Calculate(request);
            return Ok(new { Result = result });
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}

