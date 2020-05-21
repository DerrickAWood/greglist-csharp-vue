using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using fullstack_gregslist.Models;

namespace fullstack_gregslist.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Car Create(Car newCar)
    {
      string sql = @"
        INSERT INTO cars
        (make, model, imgUrl, decription, productionYear, price, userId)
        VALUES
        (@Make, @Model, @ImgUrl, @Decription, @ProductionYear, @Price, @UserId);
        SELECT LAST_INSERT_ID()";
      newCar.Id = _db.ExecuteScalar<int>(sql, newCar);
      return newCar;
    }

    internal IEnumerable<Car> GetAll()
    {
      string sql = "SELECT * FROM cars";
      return _db.Query<Car>(sql);
    }
  }
}