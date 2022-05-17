using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace GatewaySender;

public class MailSender : ISender
{
    [Required]
    public string ServerAddress { get; set; }
    [Required]
    public int Port { get; set; }

    public string Login { get; set; }
    [Required]
    public string Password { private get; set; }
    public bool SSL { get; set; } = false;
    /// <summary>
    /// Sending e-mail message
    /// </summary>
    /// <param name="from">sender</param>
    /// <param name="to">recipient</param>
    /// <param name="message">text message</param>
    /// <returns>true if success sending</returns>
    public bool Send(string from, string to, string message)
    {
        using var mes = new MailMessage(from, to);
        mes.Body = message;

        var login = new MailAddress(from).Address.ToString();
        using var mailClient = new SmtpClient(ServerAddress, Port);
        mailClient.Credentials = new NetworkCredential(login, Password);
        mailClient.EnableSsl = SSL;

        try
        {
            mailClient.Send(mes);
            return true;
        }
        catch (Exception e)
        {
            Trace.TraceError(e.ToString());
            throw;
        }
    }
}