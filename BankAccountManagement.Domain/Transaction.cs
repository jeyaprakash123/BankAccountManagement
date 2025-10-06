using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagement.Domain
{
    public class Transaction
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public bool? IsTransactionSuccess { get; set; }

    }
}
