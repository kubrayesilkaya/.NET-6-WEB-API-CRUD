using Microsoft.EntityFrameworkCore;
using User_Management_v2.Data;
using User_Management_v2.DTOs;
using User_Management_v2.Entities;

namespace User_Management_v2.Services
{
    public class UserService
    {
        private readonly UsersDBContext _dbContext;
        public UserService(UsersDBContext context)
        {
            _dbContext = context;
        }

        public string AddUser(UserRequestModel userRequestModel)
        {

            if (userRequestModel.Position != "A")
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.E_MAIL == userRequestModel.E_MAIL);

                if (user != null)
                {
                    return "this user is already exist";
                }

                Users userEntity = new Users();
                userEntity.USERNAME = userRequestModel.USERNAME;
                userEntity.IS_DELETED = false;
                userEntity.PASSWORD = userRequestModel.PASSWORD;
                userEntity.E_MAIL = userRequestModel.E_MAIL;

                _dbContext.Users.Add(userEntity);
                _dbContext.SaveChanges();

                return "Kullanıcı başarılı şekilde eklendi.";

            }
            else
            {
                return "Pozisyon bilgisi A olduğu için kayıt edilemez.";
            }

        }

        public List<Users> GetUsers()
        {
            var users = _dbContext.Users.ToList();
            return (users);
        }

        public Users GetUsersByID(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.ID_USER == id);
            return (user);
        }

        public string UpdateUser(int id, UserRequestModel updatedUser)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.ID_USER == id);

            if (user == null)
            {
                return "Geçersiz kullanıcı!";
            }

            user.USERNAME = updatedUser.USERNAME;
            user.PASSWORD = updatedUser.PASSWORD;
            user.E_MAIL = updatedUser.E_MAIL;

            _dbContext.SaveChanges();

            return ("Kullanıcı bilgileri güncellendi.");
        }

        public string DeleteUser(int  id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.ID_USER == id);

            if (user == null)
            {
                return "Geçersiz kullanıcı!";
            }

            if (!user.IS_DELETED)
            {
                user.IS_DELETED = true;
                _dbContext.SaveChanges();

                return "Kullanıcı başarı ile silindi.";
            }
            else
            {
                return "Bu kullanıcı bilgileri daha önce silinmiş!";
            }
        }

    }
}
