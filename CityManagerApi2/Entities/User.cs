namespace CityManagerApi2.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public virtual List<City>? Cities { get; set; }
    }
}
