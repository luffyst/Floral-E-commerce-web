using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Order
   {
        [Key]
        public int OrderId { get; set; }

        public int BouqId { get; set; }

        public int CustId { get; set; }

        public int Quantity { get; set; }

        public string DiliveryAddress { get; set; }


        public string Status { get; set; }

        [ForeignKey("BouqId")]
        public Bouquet Bouquet { get; set; }

        [ForeignKey("CustId")]
        public Customer Customer { get; set; }
    }
}
