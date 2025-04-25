using System.Collections.Generic;

namespace TestHotelBookingAPI.Models
{
  public class Room
  {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Floor { get; set; }

    public List<Booking> Bookings { get; set; } = new();
  }
}
