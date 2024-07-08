using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class User
    {
        [Key]
        public int UId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
