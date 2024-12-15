using Microsoft.AspNetCore.Mvc;
using ParkingLotManagement.Models;
using ParkingLotManagement.Repositories;

namespace ParkingLotManagement.Controllers
{
    [ApiController]
    [Route("api/ParkingSpots")]
    public class ParkingSpotsController : Controller
    {
        private readonly ParkingSpotRepository _parkingSpotRepository;
        public ParkingSpotsController(ParkingSpotRepository parkingSpotRepository)
        {
            _parkingSpotRepository = parkingSpotRepository;
        }
        [HttpPost()]
        public IActionResult CreateParkingSpot(ParkingSpots parkingSpot)
        {
            _parkingSpotRepository.CreateParkingSpot(parkingSpot);
            return Ok();
        }
        // request qe kthen numrin e subsciberave ose vendet e rezervuara
        [HttpGet("Reserved")]
        public IActionResult GetReservedSpots()
        {
            int activeSubscriberCount = _parkingSpotRepository.GetReservedSpots();
            return Ok(activeSubscriberCount);
        }
        [HttpGet("Total")]
        public IActionResult GetTotalSpots()
        {
            int totalSpots = _parkingSpotRepository.GetTotalSpots();
            return Ok(totalSpots);
        }
        //request qe kthen vendet e lira = total - reserved
        [HttpGet("Free")]
        public IActionResult GetFreeSpots()
        {
            int freeSpots = _parkingSpotRepository.GetFreeSpots();
            return Ok(freeSpots);
        }
        //Rrequest qe BEN update ParkingSpot qe merr si parameter ID
        [HttpPut("{Id}")]
        public IActionResult UpdateParkingSpot(int Id, ParkingSpots updatedParkingSpot)
        {
            var parkingSpot = new ParkingSpots
            {
                Id = Id,
                TotalSpots = updatedParkingSpot.TotalSpots
            };
            _parkingSpotRepository.UpdateParkingSpot(parkingSpot);
            return Ok();
        }
        [HttpGet("Occupied/Reserved")]
        public IActionResult GetOccupiedReservedSpots()
        {
            int occupiedReservedSpots = _parkingSpotRepository.GetOccupiedReservedSpots();
            return Ok(occupiedReservedSpots);
        }
        [HttpGet("Occupied/Regular")]
        public IActionResult GetOccupiedRegularSpots()
        {
            int occupiedRegularSpots = _parkingSpotRepository.GetOccupiedRegularSpots();
            return Ok(occupiedRegularSpots);
        }
    }
}
