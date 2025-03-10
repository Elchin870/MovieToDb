namespace CityManagerApi2.Entities
{
    public class CityImage
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public virtual City? City { get; set; }
        public string Url { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}
