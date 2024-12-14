namespace ParkingLotManagement.Models
{
    public class Subscriptions
    {
        public int Id { get; set; }
        public string Code { get; set; } //?????
        public double Price { get; set; }
        public double DiscountValue { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public int SubscribersId { get; set; }
        public Subscribers Subscribers { get; set; }


    }
    
}
