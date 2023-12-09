[ApiController]
[Route("api/flights")]
public class FlightsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FlightsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Flight>> GetFlights()
    {
        var flights = _context.Flights.ToList();
        return Ok(flights);
    }

    [HttpGet("{id}")]
    public ActionResult<Flight> GetFlightById(int id)
    {
        var flight = _context.Flights.Find(id);
        if (flight == null)
        {
            return NotFound();
        }

        return Ok(flight);
    }

    [HttpPost]
    public ActionResult<Flight> CreateFlight(Flight flight)
    {
        _context.Flights.Add(flight);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetFlightById), new { id = flight.FlightId }, flight);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFlight(int id, Flight updatedFlight)
    {
        var flight = _context.Flights.Find(id);
        if (flight == null)
        {
            return NotFound();
        }

        flight.FlightNumber = updatedFlight.FlightNumber;
        flight.DepartureAirport = updatedFlight.DepartureAirport;
        flight.ArrivalAirport = updatedFlight.ArrivalAirport;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFlight(int id)
    {
        var flight = _context.Flights.Find(id);
        if (flight == null)
        {
            return NotFound();
        }

        _context.Flights.Remove(flight);
        _context.SaveChanges();

        return NoContent();
    }
}
