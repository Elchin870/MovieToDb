namespace CityManagerApi2.Entities
{
    public class City
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual List<CityImage>? CityImages { get; set; }
    }
}
