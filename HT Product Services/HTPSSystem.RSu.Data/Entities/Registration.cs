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
    [Table ("Registration")]
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; }
        public int ProductID { get; set; }//foreign key
        public int CustomerID { get; set; } //foreign key
        public DateTime DateOfPurchase { get; set; } 
        public string PurchaseFrom { get; set; }
        public string PurchaseProvince { get; set; }
       
    }
}
