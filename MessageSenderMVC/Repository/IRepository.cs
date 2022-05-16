namespace MessageSenderMVC;

public interface IRepository<T> where T : Person
{
    void Create(T person);
    T? ReadById(int id);
    void Update(T person);
    void Delete(int id);
    IEnumerable<T> GetAll();
}
