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

    internal Car GetById(int id)
    {
      string sql = "SELECT * FROM cars WHERE id = @id";
      return _db.QueryFirstOrDefault<Car>(sql, new {id});
    }

    internal IEnumerable<Car> GetAll()
    {
      string sql = "SELECT * FROM cars";
      return _db.Query<Car>(sql);
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM cars WHERE id = @id AND userId = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
    }
  }
}