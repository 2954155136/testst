using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace HTPSSystem.RSu.Data.Entities
{
    [Table ("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }       

        public string FirstName { get; set; }
        [Required(ErrorMessage ="First Name is required.")]
        [StringLength(50, ErrorMessage = "Firest name is limited to 50 characters")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last name is limited to 50 characters")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required.")]


        private string _ContactNumber { get; set; }

        public string ContactNumber
        {
            get
            {
                return _ContactNumber;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    _ContactNumber = null;
                }
                else
                {
                    _ContactNumber = value;
                }
             
            }
        }
        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public static string Text { get; set; }
    }
}
