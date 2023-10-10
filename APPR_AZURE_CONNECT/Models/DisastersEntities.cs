using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APPR_AZURE_CONNECT.Models
{
    public class DisastersEntities
    {
        [Key]
        public int DisId { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        [DisplayName("Location of the Disaster")]
        public string Location { get; set; }
        public string Description { get; set; }
        [DisplayName("Specify the aid you in need of")]
        public string RequiredAidTypes { get; set; }
        [DisplayName("Goods purchased")]
        public string AllocateGoods { get; set; }
        [DisplayName("Money allocated for each disaster")]
        public int AllocateMoney { get; set; }
        [DisplayName("Amount used for purchase of goods")]
        public int AllocatedMoneyLeft { get; set; }
    }
}
