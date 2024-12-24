#nullable disable

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public decimal Taxes { get; set; }
        public string TitleDeed { get; set; }
        public string Contract { get; set; }
        [Required]
        public int? ResidenceId { get; set; }
        public Residence Residence { get; set; }

        [Required]
        public int? SaleId { get; set; }
        public Sale Sale { get; set; }

    }
}