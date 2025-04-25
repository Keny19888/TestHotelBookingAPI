using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotelBookingAPI.Models;
using TestHotelBookingAPI.Data;

namespace TestHotelBookingAPI.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class ClientController : ControllerBase
  {
    private readonly ApiContext _context;

    public ClientController(ApiContext context)
    {
      _context = context;
    }

    // Create
    [HttpPost]
    public IActionResult Create([FromBody] Client client)
    {
      if (client.Id != 0)
        return BadRequest("Id должен быть равен 0 при создании.");

      _context.Clients.Add(client);
      _context.SaveChanges();

      return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
    }

    // Put
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Client client)
    {
      if (id != client.Id)
        return BadRequest("Id в URL и теле запроса не совпадают.");

      var existing = _context.Clients.Find(id);
      if (existing == null)
        return NotFound();

      existing.FirstName = client.FirstName;
      existing.LastName = client.LastName;
      existing.Age = client.Age;

      _context.SaveChanges();

      return Ok(existing);
    }

    // Get
    [HttpGet]
    public IActionResult Get(int id)
    {
      var result = _context.Clients.Find(id);

      if (result == null)
        return NotFound();

      return Ok(result);
    }

    // Delete
    [HttpDelete]
    public IActionResult Delete(int id)
    {
      var result = _context.Clients.Find(id);

      if (result == null)
        return NotFound();

      _context.Clients.Remove(result);
      _context.SaveChanges();

      return NoContent();
    }
  }
}
