using CountryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private static readonly List<Country> Countries = new List<Country>
    {
        new Country { ID = 1, CountryName = "Canada", Capital = "Ottawa" },
        new Country { ID = 2, CountryName = "Australia", Capital = "Canberra" }
    };

    // GET: api/country
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Countries);
    }

    // GET: api/country/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var country = Countries.FirstOrDefault(c => c.ID == id);
        if (country == null) return NotFound();
        return Ok(country);
    }

    // POST: api/country
    [HttpPost]
    public IActionResult Post([FromBody] Country country)
    {
        if (country == null) return BadRequest();

        country.ID = Countries.Max(c => c.ID) + 1;
        Countries.Add(country);
        return CreatedAtAction(nameof(Get), new { id = country.ID }, country);
    }

    // PUT: api/country/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Country updatedCountry)
    {
        var country = Countries.FirstOrDefault(c => c.ID == id);
        if (country == null) return NotFound();

        country.CountryName = updatedCountry.CountryName;
        country.Capital = updatedCountry.Capital;
        return NoContent();
    }

    // DELETE: api/country/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var country = Countries.FirstOrDefault(c => c.ID == id);
        if (country == null) return NotFound();

        Countries.Remove(country);
        return NoContent();
    }
}
