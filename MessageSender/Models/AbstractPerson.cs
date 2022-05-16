using System.ComponentModel.DataAnnotations;

namespace MessageSender;

public abstract class AbstractPerson
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string EMail { get; set; }
    
    [Phone]
    public string Phone { get; set; }

    public abstract void CopyDataFrom(AbstractPerson abstractPerson);
}
