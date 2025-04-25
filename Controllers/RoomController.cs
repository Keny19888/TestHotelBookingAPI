using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotelBookingAPI.Models;
using TestHotelBookingAPI.Data;

namespace TestHotelBookingAPI.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class RoomController : ControllerBase
  {
    private readonly ApiContext _context;

    public RoomController(ApiContext context)
    {
      _context = context;
    }

    // Create
    [HttpPost]
    public IActionResult Create([FromBody] Room room)
    {
      if (room.Id != 0)
        return BadRequest("Id должен быть равен 0 при создании.");

      _context.Rooms.Add(room);
      _context.SaveChanges();

      return CreatedAtAction(nameof(Get), new { id = room.Id }, room);
    }

    // Put
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Room room)
    {
      if (id != room.Id)
        return BadRequest("Id в URL и теле запроса не совпадают.");

      var existing = _context.Rooms.Find(id);
      if (existing == null)
        return NotFound();

      existing.Name = room.Name;
      existing.Floor = room.Floor;

      _context.SaveChanges();

      return Ok(existing);
    }

    // Get
    [HttpGet]
    public IActionResult Get(int id)
    {
      var result = _context.Rooms.Find(id);

      if (result == null)
        return NotFound();

      return Ok(result);
    }

    // Delete
    [HttpDelete]
    public IActionResult Delete(int id)
    {
      var result = _context.Rooms.Find(id);

      if (result == null)
        return NotFound();

      _context.Rooms.Remove(result);
      _context.SaveChanges();

      return NoContent();
    }
  }
}
