using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        [Column("Id")]
        public int ID { get; set; }

        [NotMapped]
        public int Id
        {
            get { return this.ID; }
        }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public string TICARET_SICIL_NO { get; set; }
        [NotMapped]
        public string strID { get; set; }

    }
}
