using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAccountManagement.Domain
{
    public class Account
    {
        [Key]
        public string AccountNumber { get; set; }

        public string AccountType { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public double Balance { get; set; }

        public bool IsAadharVerify { get; set; }

        public bool IsActive { get; set; }
    }

}
