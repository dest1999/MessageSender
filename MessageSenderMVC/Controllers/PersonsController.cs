using Microsoft.AspNetCore.Mvc;

namespace MessageSenderMVC.Controllers
{
    public class PersonsController : Controller
    {
        private IRepository<Person> personRepository;

        public PersonsController(IRepository<Person> PersonRepository)
        {
            personRepository = PersonRepository;
        }

        public IActionResult Index()
        {
            var tmp = personRepository.GetAll();
            //var tmp = personRepository.ReadById(1);
            return View(tmp);
        }

        public IActionResult Create()
        {
            return View(new PersonViewModel());
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel personViewModel)
        {
            var person = new Person();
            person.CopyDataFrom(personViewModel);
            personRepository.Create(person);
            return RedirectToAction("Index");
        }
    }
}
