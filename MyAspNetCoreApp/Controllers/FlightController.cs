[ApiController]
[Route("api/flights")]
public class FlightsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Flight>> GetFlights()
    {
       
        return Ok();
    }

    [HttpGet("{id}")]
    public ActionResult<Flight> GetFlightById(int id)
    {
        
        return Ok();
    }

    [HttpPost]
    public ActionResult<Flight> CreateFlight(Flight flight)
    {
        
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFlight(int id, Flight updatedFlight)
    {
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFlight(int id)
    {
        
        return Ok();
    }
}
