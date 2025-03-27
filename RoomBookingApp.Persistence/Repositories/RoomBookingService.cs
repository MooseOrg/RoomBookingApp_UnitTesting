using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Domain;

namespace RoomBookingApp.Persistence.Repositories;
public class RoomBookingService : IRoomBookingService
{
    private readonly RoomBookingAppDbContext _context;

    public RoomBookingService(RoomBookingAppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Room> GetAvailableRooms(DateTime date)
    {
        return _context.Rooms.Where(r => !r.RoomBookings.Any(rb => rb.Date == date)).ToList();
    }

    public void Save(RoomBooking roomBooking)
    {
        _context.Add(roomBooking);
        _context.SaveChanges();
    }
}
