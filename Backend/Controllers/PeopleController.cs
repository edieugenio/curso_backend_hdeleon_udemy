using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == id);

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult Add(People person)
        {
            if (string.IsNullOrEmpty(person.Name))
            {
                return BadRequest();
            }

            Repository.People.Add(person);

            return NoContent();
        }

    }

    public class Repository
    {
        public static List<People> People = new List<People>()
        {
            new People(){
                Id = 1, Name="Pedro", BirthDate=new DateTime(1990, 12, 3)
            },
            new People(){
                Id = 2, Name="Luis", BirthDate=new DateTime(1992, 11, 3)
            },
            new People(){
                Id = 3, Name="Ana", BirthDate=new DateTime(1985, 1, 8)
            },
            new People(){
                Id = 4, Name="Hugo", BirthDate=new DateTime(1995, 1, 30)
            }
        };
    }
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }

}
