using ParkingLotManagement.Models;

namespace ParkingLotManagement.Repositories
{
    public class ParkingSpotRepository
    {
        private readonly ParkingDbContext _context;
        public ParkingSpotRepository(ParkingDbContext context)
        {
            _context = context;
        }
        public void CreateParkingSpot(ParkingSpots parkingSpot)
        {
            _context.ParkingSpots.Add(parkingSpot);
            _context.SaveChanges();
        }
        public void UpdateParkingSpot(ParkingSpots updatedParkingSpot)
        {
            var existingParkingSpot = _context.ParkingSpots.FirstOrDefault(p => p.Id == updatedParkingSpot.Id);
            if (existingParkingSpot != null)
            {
                existingParkingSpot.TotalSpots = updatedParkingSpot.TotalSpots;
                existingParkingSpot.ReservedSpots = updatedParkingSpot.ReservedSpots;
            }
            _context.SaveChanges();
        }
        public int GetReservedSpots()
        {
            var activeSubscriberCount = _context.Subscribers.Count(subscriber => !subscriber.IsDeleted);
            return activeSubscriberCount;
        }
        public int GetTotalSpots()
        {
            var totalSpots = _context.ParkingSpots.FirstOrDefault().TotalSpots;
            return totalSpots;
        }
        public int GetFreeSpots()
        {
            int totalSpots = GetTotalSpots();
            int reservedSpots = GetReservedSpots();
            int freeSpots = totalSpots - reservedSpots;
            return freeSpots;
        }
        public int GetOccupiedRegularSpots()
        {
            var checkedInRegularSpots = _context.Logs.Count(log => log.CheckOutTime == null && log.SubscriptionsId == null);
            return checkedInRegularSpots;
        }
        public int GetOccupiedReservedSpots()
        {
            var checkedInReservedSpots = _context.Logs.Count(log => log.CheckOutTime == null && log.SubscriptionsId != null);
            return checkedInReservedSpots;
        }
    }
}
