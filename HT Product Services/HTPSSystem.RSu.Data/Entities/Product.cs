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
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ModelNumber { get; set; }
        public bool Discontinued { get; set; }
        public DateTime? DiscontinuedDate { get; set; }

        
    }
}
