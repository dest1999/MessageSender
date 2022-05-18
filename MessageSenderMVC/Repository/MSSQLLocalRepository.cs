namespace MessageSenderMVC;

public class MSSQLLocalRepository : IRepository<Person>
{
    private MSSQLLocalDBContext localDB;

    public MSSQLLocalRepository(MSSQLLocalDBContext dBServer)
    {
        localDB = dBServer;
    }

    public void Create(Person person)
    {
        throw new NotImplementedException();
    }
    public Person? ReadById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Person person)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person> GetAll()
    {
        var returnValue = localDB.Persons.ToList();
        return returnValue;
    }

}
