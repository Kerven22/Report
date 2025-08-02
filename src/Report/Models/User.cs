using System.ComponentModel.DataAnnotations;

namespace Report.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        [MaxLength(300)]
        public string PasswordHash { get; set; }

        [MaxLength(120)]
        public string Salt { get; set; }
    }
}
