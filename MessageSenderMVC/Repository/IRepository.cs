namespace MessageSenderMVC;

public interface IRepository<T> where T : Person
{
    Task CreateAsync(T person);
    T? ReadById(int id);
    Task Update(T person);
    Task Delete(int id);
    IEnumerable<T> GetAll();
}
