#nullable disable

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public bool IsFamily { get; set; }


        public List<Interview> Interviews { get; set; } = new List<Interview>();

    }
}
