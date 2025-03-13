using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SimpleBankingSystem
{
    public class AccountEntity
    {
        [Key]
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }
    }
}