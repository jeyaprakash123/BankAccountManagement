using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankAccountManagement.Domain
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; } =Guid.NewGuid();
        public int UserId { get; set; }

        [MaxLength(25)]
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
