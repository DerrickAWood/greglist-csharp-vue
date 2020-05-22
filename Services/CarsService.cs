using System;
using System.Collections.Generic;
using fullstack_gregslist.Models;
using fullstack_gregslist.Repositories;

namespace fullstack_gregslist.Controllers
{
  public class CarsService
  {
    private readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }

    internal Car Create(Car newCar)
    {
      return _repo.Create(newCar);
    }

    internal IEnumerable<Car> GetAll()
    {
      return _repo.GetAll();
    }

    public Car GetById(int id)
    {
      Car foundCar = _repo.GetById(id);
      if(foundCar == null)
      {
        throw new Exception("invalid id");
      }
      return foundCar;
    }

    internal string Delete(int id, string userId)
    {
      Car foundCar = GetById(id);
            if (foundCar.UserId != userId)
            {
                throw new Exception("not your car");
            }
            if (_repo.Delete(id, userId))
            {
                return "deleted.";
            }
            throw new Exception("ooopps");
    }
  }
}