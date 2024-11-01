using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Repository;

public class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    public async Task<ICollection<Province>> GetProvinces(int countryId)
    {
        return await context.Provinces.Where(x => x.Country.Id == countryId).ToListAsync();
    }

    public async Task<ICollection<Country>> GetCountries()
    {
        return await context.Countries.ToListAsync();
    }
}