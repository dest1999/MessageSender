using GatewaySender;

namespace MessageSenderMVC;

public class Mailer
{
    public static void Send(MailSender sender, IRepository<Person> repository)
    {
        var persons = repository.GetAll();
        foreach (var person in persons)
        {
            if (person.EMail is not null)
            {
                sender.Send(person.EMail, "strMessage");

            }
        }
    }
}
