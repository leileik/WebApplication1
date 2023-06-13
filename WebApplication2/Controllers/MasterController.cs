using Microsoft.AspNetCore.Mvc;
using WebApplication2.Bean;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MasterController : ControllerBase
    {
        private readonly ILogger<MasterController> _logger;

        public MasterController(ILogger<MasterController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Position(MasterMsg masterMsg)
        {
            Console.WriteLine(masterMsg.MapName);
            return ;
        }
    }
}