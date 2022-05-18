namespace MessageSenderMVC;

public class MSSQLLocalRepository : IRepository<Person>
{
    private MSSQLLocalDBContext localDB;

    public MSSQLLocalRepository(MSSQLLocalDBContext dBServer)
    {
        localDB = dBServer;
    }

    public async Task CreateAsync(Person person)
    {
        localDB.Add(person);
        await localDB.SaveChangesAsync();
    }
    public Person? ReadById(int id)
    {
        var returnValue = localDB.Find<Person>(id);
        return returnValue;
    }

    public async Task Update(Person person)
    {
        localDB.Update(person);
        await localDB.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        localDB.Remove<Person>(ReadById(id));
        await localDB.SaveChangesAsync();
    }

    public IEnumerable<Person> GetAll()
    {
        var returnValue = localDB.Persons.ToList();
        return returnValue;
    }

}
