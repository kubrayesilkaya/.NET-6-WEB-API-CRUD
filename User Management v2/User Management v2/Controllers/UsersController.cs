using Microsoft.AspNetCore.Mvc;
using User_Management_v2.Data;
using User_Management_v2.Entities;

namespace User_Management_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersDBContext _dbContext;
        public UsersController(UsersDBContext context) 
        {
            _dbContext = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
                                                                                                                                                                                                                                                    {
            var users = _dbContext.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Users>> GetUsersByID(int id)
        {
            var users = _dbContext.Users.FirstOrDefault(u => u.ID_USER == id);
            return Ok(users);
        }

  

        [HttpPost]
        public ActionResult<IEnumerable<Users>> AddUser([FromBody] Users newUser)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.ID_USER == newUser.ID_USER);

            if (user != null)
            {
                return BadRequest("this user is already exist");
            }

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return Ok(newUser);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.ID_USER == id);

            if (user == null)
            {
                return NotFound("invalid user!");
                //return BadRequest();
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return Ok("the user is deleted successfully");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] Users updatedtUser)
        {
            var user = _dbContext.Users.FirstOrDefault(u =>u.ID_USER == id);

            if (user == null)
            {
                return NotFound("invalid user!");
                //return BadReques();
            }

            user.USERNAME = updatedtUser.USERNAME;
            user.PASSWORD = updatedtUser.PASSWORD;

            _dbContext.SaveChanges();

            return Ok("User info is updated.");
        }


    }
}
