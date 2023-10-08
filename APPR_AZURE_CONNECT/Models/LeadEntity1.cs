using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APPR_AZURE_CONNECT.Models
{
    public class LeadEntity1
    {
        [Key]
        public int Id {  get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime DonateDate {  get; set; }
        [DisplayName("Name")]
        public string DonateName { get; set; }
        public int Item { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

    }
}
