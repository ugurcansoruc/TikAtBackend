using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "Ahmet", "Mehmet", "Taner", "Uğurcan", "Hamza", "Melih", "Doğa"
        };

        private static readonly string[] LastNames = new[]
        {
        "Çelme", "Soruç", "Şahin", "Doğan", "Akkaya", "Sanmak", "Sarı"
        };

        private static readonly int[] Ages = new[]
        {
            25, 32, 27, 19, 36, 20, 29
        };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPersons")]
        public IEnumerable<Person> Get()
        {
            return Enumerable.Range(0, 6).Select(index => new Person
            {
                firstName = Names[index],
                lastName = LastNames[index],
                age = Ages[index]
            })
            .ToArray();
        }
    }
}