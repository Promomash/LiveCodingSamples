namespace Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int CountryId { get; set; }
    public int ProvinceId { get; set; }

    public Country Country { get; set; }
    public Province Province { get; set; }
}