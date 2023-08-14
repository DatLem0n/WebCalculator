using Microsoft.AspNetCore.Mvc;

namespace calculator.Controllers;

/**
 * Handles API calls from front. Calculator can be found from localhost:5050/Calculator
 */
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
        return Ok("Connected to the calculator API (Hi :D) ");
    }
    
    /**
     * 
     */
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

