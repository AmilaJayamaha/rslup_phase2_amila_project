using Microsoft.AspNetCore.Mvc;

[Route("api/flights")]
[ApiController]
public class FlightController : ControllerBase
{
    [HttpGet]
    public IActionResult GetFlights()
    {
       
        return Ok(flights);
    }

    [HttpPost]
    public IActionResult CreateFlight([FromBody] FlightModel flight)
    {
        
        return CreatedAtAction("GetFlights", new { id = flight.Id }, flight);
    }
}
