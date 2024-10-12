using Microsoft.AspNetCore.Mvc;
using RandomDataGenerator.Models;
using System.Collections.Generic;
using System.Linq;

namespace RandomDataGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitData([FromBody] List<Personal> personals)
        {
            if (personals == null || !personals.Any())
            {
                return BadRequest("No data provided.");
            }

            // Validation for hobbies
            foreach (var personal in personals.Where((p, index) => (index + 1) % 100 == 0 && p.Hobby == "Tidur"))
            {
                return BadRequest($"Error on row {personal.Id}: does not prefer hobby 'Tidur'");
            }

            // Insert into database logic here

            return Ok("Data inserted successfully.");
        }
    }
}
