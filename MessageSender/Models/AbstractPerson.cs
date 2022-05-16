namespace MessageSender;

public abstract class AbstractPerson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string EMail { get; set; }
    public string Phone { get; set; }
    public abstract void CopyDataFrom(AbstractPerson abstractPerson);
}
