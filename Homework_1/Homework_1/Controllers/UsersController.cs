using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = StaticDb.UserNames;
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetUserById(int id)
        //{
        //    if (id >= 0 && id < StaticDb.UserNames.Count)
        //    {
        //        var user = StaticDb.UserNames[id];
        //        return Ok(user);
        //    }
        //    else
        //    {
        //        return NotFound($"User with ID {id} not found.");
        //    }
        //}

        [HttpGet("{name}")]
        public IActionResult GetUser(string name)
        {
            var user = StaticDb.UserNames.FirstOrDefault(userName => userName.Equals(name));

            if (user == null)
            {
                return NotFound($"User '{name}' not found.");
            }

            return Ok(user);

        }
    }
}
