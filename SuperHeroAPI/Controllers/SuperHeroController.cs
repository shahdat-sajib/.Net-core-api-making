using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heros = new List<SuperHero>
        {
                new SuperHero
                {
                    Id = 1,
                    Name = "Shahdat",
                    FirstName = "Sajib",
                    LastName = "Shahdat",
                    Place = "Bangladesh"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Arifa",
                    FirstName = "Arifa",
                    LastName = "Sultana",
                    Place = "Rajshahi"
                }
        };


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heros);
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<SuperHero>> Get(int Id)
        {
            var hero = heros.Find(h => h.Id == Id);
            if (hero == null)
                return BadRequest("Hero not found");
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }


        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatehero)
        {
            var hero = heros.Find(h => h.Id == updatehero.Id);
            if (hero == null)
                return BadRequest("Hero not found");
            
            hero.Name = updatehero.Name;
            hero.FirstName = updatehero.FirstName;  
            hero.LastName = updatehero.LastName;    
            hero.Place = updatehero.Place; 

            return Ok(heros);
        }
    }
}
