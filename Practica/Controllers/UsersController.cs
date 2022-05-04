using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practica.IConfiguration;
using Practica.Models;
using System.Threading.Tasks;

namespace Practica.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public UsersController(
            ILogger<UsersController> logger,
            IUnitOfWork  unitOfWork
        )
        {

            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser (User user)
        {
            if (ModelState.IsValid)
            {

            }

        }

    }
}
