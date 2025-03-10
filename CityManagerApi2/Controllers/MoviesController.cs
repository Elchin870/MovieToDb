using CityManagerApi2.Data.Abstract;
using CityManagerApi2.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;

namespace CityManagerApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IAppRepository _context;

        public MoviesController(HttpClient httpClient, IAppRepository context)
        {
            _httpClient = httpClient;
            _context = context;
        }      

        [HttpGet("getMovie")]
        public async Task<IActionResult> GetMovie()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Notes.txt");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            var lines = System.IO.File.ReadAllLines(filePath);

            var random = new Random();
            var randomWord = lines[random.Next(lines.Length)];
      
            string url = $"https://www.omdbapi.com/?apikey=e385ccd5&t={randomWord}";

            var response=await _httpClient.GetAsync(url);
            if(response == null)
            {
                return BadRequest();
            }
            var jsonResponse=await response.Content.ReadAsStringAsync();
            var movie = JsonSerializer.Deserialize<Movie>(jsonResponse);
            await _context.AddAsync(movie);
            var success = await _context.SaveAllAsync(); 

            if (!success)
            {
                return BadRequest();
            }
            return Ok(movie);
        }
    }
}
