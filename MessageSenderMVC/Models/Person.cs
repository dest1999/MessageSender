namespace MessageSenderMVC;

public class Person : AbstractPerson
{
    public override void CopyDataFrom(AbstractPerson person)
    {
        Id = person.Id;
        Name = person.Name;
        EMail = person.EMail;
        Phone = person.Phone;
    }
}
