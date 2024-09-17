using DuckData.Repo;
using DuckData.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DuckController : ControllerBase
    {
        // Fields
        private readonly ILogger<DuckController> _logger;
        private IRepository _repo;

        // Constructor
        public DuckController(ILogger<DuckController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet( "{id}" )]
        public Duck GetDuckById(int id)
        {
            return _repo.GetDuckById( id );
        }

        // Methods
        [HttpGet]
        public List<Duck> GetAllDucks()
        {
            return _repo.LoadAllDucks();
        }

        [HttpPost]
        public Duck CreateDuck([FromBody] Duck newDuck)
        {
            try
            {
                _repo.SaveDuck( newDuck );
                var ducks = _repo.LoadAllDucks();
                var duck = from d in ducks
                    where newDuck.color == d.color && newDuck.numFeathers == d.numFeathers
                    select d;
                return duck.First();
            }
            catch
            {
                return new Duck();
            }
        }

        [HttpPut]
        public string UpdateDuck()
        {
            return "Update";
        }

        [HttpDelete("{id}" )]
        public void DeleteDuck(int id)
        {
            _repo.DeleteDuckById(id);
        }
    }
}