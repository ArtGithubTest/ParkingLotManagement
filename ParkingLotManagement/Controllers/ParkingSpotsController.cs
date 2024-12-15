using Microsoft.AspNetCore.Mvc;
using ParkingLotManagement.Models;
using ParkingLotManagement.Repositories;

namespace ParkingLotManagement.Controllers
{
    [ApiController]
    [Route("api/ParkingSpots")]
    public class ParkingSpotsController : Controller
    {
        private readonly ParkingSpotsRepository _parkingSpotsRepository;
        public ParkingSpotsController(ParkingSpotsRepository parkingSpotRepository)
        {
            _parkingSpotsRepository = parkingSpotRepository;
        }
        [HttpPost()]
        public IActionResult CreateParkingSpot(ParkingSpots parkingSpot)
        {
            _parkingSpotsRepository.CreateParkingSpot(parkingSpot);
            return Ok();
        }
        // request qe kthen numrin e subsciberave ose vendet e rezervuara
        [HttpGet("Reserved")]
        public IActionResult GetReservedSpots()
        {
            int activeSubscriberCount = _parkingSpotsRepository.GetReservedSpots();
            return Ok(activeSubscriberCount);
        }
        [HttpGet("Total")]
        public IActionResult GetTotalSpots()
        {
            int totalSpots = _parkingSpotsRepository.GetTotalSpots();
            return Ok(totalSpots);
        }
        //request qe kthen vendet e lira = total - reserved
        [HttpGet("Free")]
        public IActionResult GetFreeSpots()
        {
            int freeSpots = _parkingSpotsRepository.GetFreeSpots();
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
            _parkingSpotsRepository.UpdateParkingSpot(parkingSpot);
            return Ok();
        }
        [HttpGet("Occupied/Reserved")]
        public IActionResult GetOccupiedReservedSpots()
        {
            int occupiedReservedSpots = _parkingSpotsRepository.GetOccupiedReservedSpots();
            return Ok(occupiedReservedSpots);
        }
        [HttpGet("Occupied/Regular")]
        public IActionResult GetOccupiedRegularSpots()
        {
            int occupiedRegularSpots = _parkingSpotsRepository.GetOccupiedRegularSpots();
            return Ok(occupiedRegularSpots);
        }
    }
}
