namespace App_Store.Api.Entities;

public class Apps
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int GenresId { get; set; }
    public Genres? Genres { get; set; }
    public double Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
