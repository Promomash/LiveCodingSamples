using Models;

namespace Infrastructure.Interfaces;

public interface ICountryRepository
{
    Task<ICollection<Province>> GetProvinces(int countryId);

    Task<ICollection<Country>> GetCountries();
}