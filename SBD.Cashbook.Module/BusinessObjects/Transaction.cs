using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;

//using DevExpress.Persistent.Base;
 

namespace SBD.Cashbook.Module.BusinessObjects
{
    [NavigationItem("Main")]
    public class Transaction :BasicBo
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Decimal Amount { get; set; }


        //public int DebitAccount_Id { get; set; }
        //[ForeignKey("DebitAccount_Id")]
        [Required]
        public virtual GLAccount DebitAccount { get; set; }

        //public int CreditAccount_Id { get; set; }
        //[ForeignKey("CreditAccount_Id")]
        [Required]
        public virtual  GLAccount CreditAccount { get; set; }
        
        [MaxLength(20)]
        [System.ComponentModel.DataAnnotations.Schema.Index( IsUnique = true)]
        public string BankId { get; set; }
        public string Memo { get; set; }

        
        public virtual Job job { get; set; }
        public virtual Card Card { get; set; }
    }
}