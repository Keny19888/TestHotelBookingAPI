using System.Collections.Generic;

namespace TestHotelBookingAPI.Models
{
  public class Client
  {
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int Age { get; set; }

    public List<Booking> Bookings { get; set; } = new();
  }
}
