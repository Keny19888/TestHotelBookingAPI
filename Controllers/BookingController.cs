using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotelBookingAPI.Models;
using TestHotelBookingAPI.Data;

namespace TestHotelBookingAPI.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class BookingController : ControllerBase
  {
    private readonly ApiContext _context;

    public BookingController(ApiContext context)
    {
      _context = context;
    }

    // Create
    [HttpPost]
    public IActionResult Create([FromBody] Booking booking)
    {
      if (booking.Id != 0)
        return BadRequest("Id должен быть равен 0 при создании.");

      _context.Bookings.Add(booking);
      _context.SaveChanges();

      return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
    }

    // Put
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Booking booking)
    {
      if (id != booking.Id)
        return BadRequest("Id в URL и теле запроса не совпадают.");

      var existing = _context.Bookings.Find(id);
      if (existing == null)
        return NotFound();

      existing.BookingDate = booking.BookingDate;
      existing.ClientId = booking.ClientId;
      existing.RoomId = booking.RoomId;

      _context.SaveChanges();

      return Ok(existing);
    }

    // Get
    [HttpGet]
    public IActionResult Get(int id)
    {
      var result = _context.Bookings.Find(id);

      if (result == null)
        return NotFound();

      return Ok(result);
    }

    // Delete
    [HttpDelete]
    public IActionResult Delete(int id)
    {
      var result = _context.Bookings.Find(id);

      if (result == null)
        return NotFound();

      _context.Bookings.Remove(result);
      _context.SaveChanges();

      return NoContent();
    }
  }
}
