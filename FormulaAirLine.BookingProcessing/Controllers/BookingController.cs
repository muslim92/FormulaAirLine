using FormulaAirLine.API.Services;
using FormulaAirLine.BookingProcessing.Controllers;
using FormulaAirLine.BookingProcessing.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaAirLine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IMessageProducer _messageProducer;

        //In-Memory db
        public static readonly List<Booking> _bookings = new();
        public BookingController(ILogger<BookingController> logger, IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking newBooking)
        {
            if (!ModelState.IsValid) return BadRequest();

            _bookings.Add(newBooking);

            _messageProducer.SendingMessage<Booking>(newBooking);

            return Ok();
        }

    }
}
