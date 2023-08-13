using Azure;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        [Tags("READ | Kullacını bilgilerini görüntüle :")]
        [HttpGet]
        [Route("[action]")] //metot ismi ile route aynı ise [action] yazabiliriz.
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [Tags("READ | ID değeri ile kullanıcı görüntüle :")]
        [HttpGet("GetUsersByID")]
        public ActionResult<Users> GetUsersByID(int id)
        {
            var user = _userService.GetUsersByID(id);
            return Ok(user);
        }

        //POST***********************************************************************************

        [Tags("CREATE |Yeni kullanıcı ekle :")]
        [Route("[action]")]
        [HttpPost]
        public ActionResult<IEnumerable<string>> AddUser([FromBody] UserRequestModel userRequestModel)
        {
            var response = _userService.AddUser(userRequestModel);

            return Ok(response);    
        }

        //DELETE***********************************************************************************

        [Tags("DELETE | Kullanıcı sil : ")]
        [Route("[action]/{id}")]
        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            var response = _userService.DeleteUser(id);
            return Ok(response);
        }

        //PUT***********************************************************************************

        [Tags("UPDATE | Kullanıcı bilgilerini güncelle : ")]
        [Route("[action]/{id}")]   
        [HttpPut]
        public ActionResult UpdateUser(int id, [FromBody] UserRequestModel updatedUser)
        {
            var response = _userService.UpdateUser(id, updatedUser);
            
            return Ok(response);
        }


    }
}
