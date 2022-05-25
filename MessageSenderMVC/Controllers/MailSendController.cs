using GatewaySender;
using Microsoft.AspNetCore.Mvc;

namespace MessageSenderMVC.Controllers
{
    public class MailSendController : Controller
    {
        private MailSender sender;
        public MailSendController(MailSender Sender)
        {
            sender = Sender;
        }

        public IActionResult Index()
        {
            return View(sender);
        }

        public IActionResult Edit()
        {
            return View(sender);
        }

        [HttpPost]
        public IActionResult Edit(MailSender Sender)
        {
            sender.ServerAddress = Sender.ServerAddress;
            sender.Port = Sender.Port;
            sender.Login = Sender.Login;
            sender.Password = Sender.Password;
            sender.SSL = Sender.SSL;
            return RedirectToAction("Index");
        }
        

    }
}
