using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APPR_AZURE_CONNECT.Models
{
    public class MonetDonateEntity
    {
        [Key]
        [DisplayName("Name")]
        public string DonatorsName { get; set; }
        [DisplayName("Date")]
        public DateTime DonationDate { get; set; }
        public int Amount { get; set; }
    }
}
