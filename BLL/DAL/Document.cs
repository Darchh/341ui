#nullable disable

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Taxes { get; set; }
        [Required]
        public string TitleDeed { get; set; }
        [Required]
        public string Contract { get; set; }
        [Required]
        public int? ResidenceId { get; set; }
        public Residence Residence { get; set; }
        [Required]
        public int? SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}