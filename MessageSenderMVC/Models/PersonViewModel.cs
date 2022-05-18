using Microsoft.AspNetCore.Mvc;

namespace MessageSenderMVC;

public class PersonViewModel : AbstractPerson
{
    [HiddenInput]
    new int Id { get; set; }
    public override void CopyDataFrom(AbstractPerson person)
    {
        Id = person.Id;
        Name = person.Name;
        EMail = person.EMail;
        Phone = person.Phone;
    }
}
