using Microsoft.EntityFrameworkCore;
using User_Management_v2.Entities;

namespace User_Management_v2.Data
{
    public class UsersDBContext : DbContext
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options) 
        {
        }
        public DbSet<Users> Users { get; set; }

    }
}
