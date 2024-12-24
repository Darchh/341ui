using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal Deposit { get; set; }

  
        public List<Document> Documents { get; set; } = new List<Document>();
        public List<Interview> Interviews { get; set; } = new List<Interview>();
    }
}
