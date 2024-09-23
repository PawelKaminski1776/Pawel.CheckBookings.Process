using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using System.Threading.Tasks;

namespace BowlingSys.Process.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMessageSession _messageSession;

        public BaseController(IMessageSession messageSession)
        {
            _messageSession = messageSession;
        }

        protected async Task<IActionResult> HandleMessage<TMessage>(TMessage message)
        {
            await _messageSession.Send(message);
            return Ok();
        }
    }
}
