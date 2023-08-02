using Microsoft.AspNetCore.Mvc;
using User_Management_v2.Data;
using User_Management_v2.DTOs;
using User_Management_v2.Entities;
using User_Management_v2.Services;

namespace User_Management_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersDBContext _dbContext;
        private readonly UserService _userService;
        public UsersController(UsersDBContext context, UserService userService)
        {
            _dbContext = context;
            _userService = userService;
        }


        //GET***********************************************************************************

        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<Users> GetUsersByID(int id)
        {
            var user = _userService.GetUsersByID(id);

            if (user == null)
            {
                return NotFound("User not found!");
            }

            return Ok(user);
        }

        //POST***********************************************************************************

        [HttpPost]
        public ActionResult<IEnumerable<string>> AddUser([FromBody] UserRequestModel userRequestModel)
        {
            var response = _userService.AddUser(userRequestModel);

            return Ok(response);
        }

        //DELETE***********************************************************************************

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var response = _userService.DeleteUser(id);
            return Ok(response);
        }

        //PUT***********************************************************************************

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserRequestModel updatedUser)
        {
            var response = _userService.UpdateUser(id, updatedUser);
            
            return Ok(response);
        }


    }
}
