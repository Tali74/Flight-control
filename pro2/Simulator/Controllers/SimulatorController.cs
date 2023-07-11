using Microsoft.AspNetCore.Mvc;

namespace Simulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulatorController : ControllerBase
    {
        private readonly Simulator simulator;

        public SimulatorController(Simulator simulator)
        {
            this.simulator = simulator;
        }
        [HttpGet("start")]
        public void Start()
        {
            _ = simulator.Start();
        }
    }
}
