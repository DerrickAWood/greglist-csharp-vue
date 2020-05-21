using System;
using System.Collections.Generic;
using System.Security.Claims;
using fullstack_gregslist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fullstack_gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;

    public CarsController(CarsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAll()
    {
      try
      {
          return Ok(_cs.GetAll());
      }
      catch (System.Exception)
      {
          
          throw;
      }
    }
  [Authorize]
    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Not logged in");
        }
        newCar.UserId = user.Value;
        return Ok(_cs.Create(newCar));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}