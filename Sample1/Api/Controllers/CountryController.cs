﻿using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(ICountryRepository countryRepository) : ControllerBase
    {
        [HttpGet]
        [Route("{countryId}/GetProvinces")]
        public async Task<IActionResult> GetByCountry(int countryId)
        {
            var result = await countryRepository.GetProvinces(countryId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await countryRepository.GetCountries();
            return Ok(result);
        }
    }
}
