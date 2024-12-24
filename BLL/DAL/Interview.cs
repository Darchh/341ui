using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Interview
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();

        [Required]
        public int? AgentId { get; set; }
        public Agent Agent { get; set; } = new Agent();

        [Required]
        public int? SaleId { get; set; }
        public Sale Sale { get; set; } = new Sale();




    }
}
