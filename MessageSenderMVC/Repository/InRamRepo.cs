namespace MessageSenderMVC;

public class InRamRepo //: IRepository<Person>
{
    private List<Person> repository = new()
    {
        new Person() { Id = 1, Name = "Id1", EMail = "123@321.1" },
        new Person() { Id = 2, Name = "Id2", EMail = "123@321.1" },
        new Person() { Id = 3, Name = "Id3", EMail = "123@321.1" },
    };


    public void Create(Person person)
    {
        if (repository.Count < 1)
        {
            person.Id = 1;
            repository.Add(person);
        }
        else
        {
            person.Id = repository[^1].Id + 1;
            repository.Add(person);
        }
    }

    public Person? ReadById(int id) => repository.FirstOrDefault(x => x.Id == id);

    public void Update(Person person)
    {
        var tmpPerson = ReadById(person.Id);
        if (tmpPerson != null)
        {
            tmpPerson.CopyDataFrom(person);
        }
    }

    public void Delete(int id) => repository.RemoveAll(x => x.Id == id);

    public IEnumerable<Person> GetAll() => repository;
}
