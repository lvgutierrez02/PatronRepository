using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practica.IConfiguration;
using Practica.Models;
using System;
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
                user.UserId = Guid.NewGuid();

                await _unitOfWork.Users.Add(user);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetItem", new { user.UserId}, user);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetItem(Guid id) { 
        
            var user = await _unitOfWork.Users.GetById(id);

            if (user == null)
                return NotFound(); //404 http status code
        

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var users = await _unitOfWork.Users.All();
            return Ok(users);
        }

        [HttpPost("{UserId}")]
        public async Task<IActionResult> UpdateItem(Guid id, User user) 
        {
            if(id!=user.UserId)
                return BadRequest();

            await _unitOfWork.Users.Upsert(user);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteItem(Guid id) 
        {
            var item = await _unitOfWork.Users.GetById(id);

            if(item == null)
                return BadRequest();

            await _unitOfWork.Users.Delete(id);
            await _unitOfWork.CompleteAsync();  

            return Ok(id);
        }

    }
}
