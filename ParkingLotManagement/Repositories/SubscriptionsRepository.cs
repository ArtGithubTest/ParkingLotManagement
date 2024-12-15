using ParkingLotManagement.Models;

namespace ParkingLotManagement.Repositories
{
    public class SubscriptionsRepository
    {
        private readonly ParkingDbContext _context;
        public SubscriptionsRepository(ParkingDbContext context)
        {
            _context = context;
        }

        public void CreateSubscription(Subscriptions subscription)
        {
            if (_context.Subscriptions.Any(x => x.Code == subscription.Code))
            {
                throw new Exception("Subscription with this code already exists");
            }
            else
            {
                _context.Subscriptions.Add(subscription);
                _context.SaveChanges();
            }
        }

        public List<Subscriptions> GetSubscriptionsByCode(string code)
        {
            var subscriptions = _context.Subscriptions.Where(x => x.Code == code).ToList();
            return subscriptions;
        }
    }
}
