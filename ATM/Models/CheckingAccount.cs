using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATM.Models
{
    public class CheckingAccount
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name="Last Name")]
        [Required]
        public string LastName { get; set; }


        [StringLength(10)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"\d{6,10}", ErrorMessage ="Account Number must be between 6 to 10 digits")]
        [Display(Name ="Account #")]
        [Required]
        public string AccountNumber { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }


        public string Name
        {
            get
            {
                return String.Format("{0} {1}", this.FirstName, this.LastName);
            }
            
        }

        public virtual ApplicationUser User { get; set; }
        public string ApplicationUserId { get; set; }

    }
}