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

        public IActionResult Edit(int id)
        {
            var returnValue = personRepository.ReadById(id);
            
            return View(returnValue);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            personRepository.Update(person);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            //var personVM = new PersonViewModel();
            //personVM.CopyDataFrom(personRepository.ReadById(id));
            return View(personRepository.ReadById(id));
        }

        [HttpPost]
        public IActionResult Delete(Person person)
        {
            personRepository.Delete(person.Id);

            return RedirectToAction("Index");
        }

    }
}
