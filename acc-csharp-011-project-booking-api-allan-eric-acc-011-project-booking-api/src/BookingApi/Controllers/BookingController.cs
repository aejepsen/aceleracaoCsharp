using Microsoft.AspNetCore.Mvc;
using BookingApi.Models;
using BookingApi.Repository;

namespace BookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly BookingRepository _repository;

    public BookingController(BookingRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.GetBookings());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var booking = _repository.GetBooking(id);
        if (booking == null)
        {
            return NotFound();
        }
        return Ok(booking);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Booking booking)
    {
        if (booking == null)
        {
            return BadRequest();
        }
        _repository.AddBooking(booking);
        return CreatedAtAction("Get", new { id = booking.Id }, booking);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Booking booking)
    {
        if (booking == null || booking.Id != id)
        {
            return BadRequest();
        }
        var bookingInDb = _repository.GetBooking(id);
        if (bookingInDb == null)
        {
            return NotFound();
        }
        _repository.UpdateBooking(booking);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var bookingInDb = _repository.GetBooking(id);
        if (bookingInDb == null)
        {
            return NotFound();
        }
        _repository.RemoveBooking(bookingInDb);
        return NoContent();
    }


    [HttpPost("reserve")]
    public IActionResult ReserveHotel([FromBody] Booking booking)
    {
        try {
            var bookingCreated = _repository.MakeReservation(booking.UserId, booking.HotelId, booking.CheckIn, booking.CheckOut);
            if (bookingCreated == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("ReserveHotel", new { id = bookingCreated.Id }, bookingCreated);
        }
        catch (InvalidOperationException e) {
            if (e.Message == "No rooms available")
            {
                return BadRequest(e.Message);
            }
            else
            {
                return NotFound(e.Message);
            }
        }
    }
}
