using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace GatewaySender;

//public interface IMailSender : ISender { }

public class MailSender : ISender
{
    [Required]
    public string ServerAddress { get; set; }//SMTP adress?
    [Required]
    public int Port { get; set; }

    public string Login { get; set; }//full name (user@server)
    [Required]
    public string Password { get; set; }
    public bool SSL { get; set; } = false;
    /// <summary>
    /// Sending e-mail message
    /// </summary>
    /// <param name="to">recipient</param>
    /// <param name="message">text message</param>
    /// <returns>true if success sending</returns>
    public bool Send(/*string from, */string to, string message)
    {
        using var mes = new MailMessage(Login, to);
        mes.Subject = "Data from " + DateTime.Now.ToString();
        mes.Body = message;
        mes.IsBodyHtml = true;
        using var mailClient = new SmtpClient(ServerAddress, Port);
        mailClient.Credentials = new NetworkCredential(mes.From.User, Password);
        mailClient.EnableSsl = SSL;

        try
        {
            mailClient.Send(mes);
            return true;
        }
        catch (Exception e)
        {
            Trace.TraceError(e.ToString());
            Trace.TraceError($"Error sending to recipient: {to}");
            return false;
        }
    }
}