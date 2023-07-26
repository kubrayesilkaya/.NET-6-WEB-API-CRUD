using System.ComponentModel.DataAnnotations;

namespace User_Management_v2.Entities
{
    public class Users
    {
        [Key]
        public int ID_USER { get; set; }

        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public bool IS_DELETED { get; set; }
        public string E_MAIL { get; set; }


    }
}
