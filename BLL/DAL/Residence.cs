#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BLL.DAL
{
    public class Residence
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public bool IsAvailable { get; set; }


        public List<Document> Documents { get; set; } = new List<Document>();
    }
}
