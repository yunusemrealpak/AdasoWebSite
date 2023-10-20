using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        [Column("ProductId")]
        public int ID { get; set; }
        [NotMapped]
        public int ProductId
        {
            get { return this.ID; }
        }

        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string strID { get; set; }
    }

}
