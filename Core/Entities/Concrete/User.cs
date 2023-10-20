using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        [Column("Id")]
        public int ID { get; set; }

        [NotMapped]
        public int Id
        {
            get { return this.ID; }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        [NotMapped]
        public string TICARET_SICIL_NO { get; set; }
        [NotMapped]
        public string strID { get; set; }
    }
}
