namespace fullstack_gregslist.Models
{
  public class Car
  {
    public int Id { get; set; }

    public string Make { get; set; }
    public string Model { get; set; }
    public string ImgUrl { get; set; }
    public string Decription { get; set; }
    public int ProductionYear { get; set; }
    public decimal Price { get; set; }



    public string UserId { get; set; }
  }
}