﻿using Microsoft.AspNetCore.Mvc;
using ParkingLotManagement.Models;
using ParkingLotManagement.Repositories;

namespace ParkingLotManagement.Controllers
{
    [ApiController]
    [Route("api/Subscribers")]
    public class SubscribersController : Controller
    {
        private readonly SubscribersRepository _subscribersRepository;
        public SubscribersController(SubscribersRepository subscribersRepository)
        {
            _subscribersRepository = subscribersRepository;
        }
        [HttpPost]
        public IActionResult CreateSubscriber(Subscribers subscriber)
        {
            _subscribersRepository.CreateSubscribers(subscriber);
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateSubscribers(Subscribers subscriber)
        {
            _subscribersRepository.UpdateSubscribers(subscriber);
            return Ok();
        }
        [HttpGet("FirstName")]
        public IActionResult GetSubscribersByFirstName(string firstName)
        {
            var subscribersList = _subscribersRepository.GetSubscribersByFirstName(firstName);
            return Ok(subscribersList);
        }
        [HttpGet("LastName")]
        public IActionResult GetSubscribersByLastName(string lastName)
        {
            var subscribersList = _subscribersRepository.GetSubscribersByLastName(lastName);
            return Ok(subscribersList);
        }
        [HttpGet("IdCardNumber")]
        public IActionResult GetSubscribersByIdCardNumber(string idCardNumber)
        {
            var subscribersList = _subscribersRepository.GetSubscribersByIdCardNumber(idCardNumber);
            return Ok(subscribersList);
        }
        [HttpGet("Email")]
        public IActionResult GetSubscribersByEmail(string email)
        {
            var subscribersList = _subscribersRepository.GetSubscribersByEmail(email);
            return Ok(subscribersList);
        }
        [HttpGet("Id")]
        public IActionResult GetById(int id)
        {
            var subscribersList = _subscribersRepository.GetById(id);
            return Ok(subscribersList);
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteSubscribers(Subscribers subscriberId)
        {
            _subscribersRepository.DeleteSubscribers(subscriberId);
            return Ok();
        }
    }
}
