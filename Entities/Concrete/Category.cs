using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        [Column("CategoryId")]
        public int ID { get; set; }

        [NotMapped]
        public int CategoryId
        {
            get { return this.ID; }
        }
        public string CategoryName { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
