namespace MessageSenderMVC;

public class PersonViewModel : AbstractPerson
{
    public override void CopyDataFrom(AbstractPerson person)
    {
        Id = person.Id;
        Name = person.Name;
        EMail = person.EMail;
        Phone = person.Phone;
    }
}
