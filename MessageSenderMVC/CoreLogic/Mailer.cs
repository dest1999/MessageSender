using GatewaySender;
using System.Text;
using RazorEngine;
using RazorEngine.Templating;
namespace MessageSenderMVC;

public class PersonForMailing
{
    public Person person { get; set; }
    public int[] metrix { get; set; }
}

public class Mailer
{
    public static void Send(MailSender sender, IRepository<Person> repository)
    {
        List<Person> persons = (List<Person>)repository.GetAll();
        var stringTemplate =
            @"
                <html><body>
                <H4>Statistic message for user:</H4>
                <p>@Model.person.Name</p>
                <p>Total items: @Model.metrix.Length</p>
                    @foreach(var item in Model.metrix)
                    {
                        @item;
                        <br>
                    }
                
                </body></html>
            ";
        _ = Engine.Razor.RunCompile(stringTemplate, "mailTemplate", typeof(PersonForMailing), new PersonForMailing()
            {
                person = persons[0],
                metrix = FakedataProvider.GetData().ToArray()
            }
        );

        foreach (var person in persons)
        {
            if (person.EMail is not null)
            {
                var tmp = new PersonForMailing() 
                { 
                    person = person,
                    metrix = FakedataProvider.GetData().ToArray()
                };

                string? resultTemplate = Engine.Razor.Run("mailTemplate", typeof(PersonForMailing), tmp);
                sender.Send(person.EMail, resultTemplate);
            }
        }
    }
}
