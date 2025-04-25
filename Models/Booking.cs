namespace TestHotelBookingAPI.Models
{
  public class Booking
  {
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }

    // Внешний ключ к Room
    public int RoomId { get; set; }
    public Room? Room { get; set; }

    // Внешний ключ к Client
    public int ClientId { get; set; }
    public Client? Client { get; set; }
  }
}
