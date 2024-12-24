#nullable disable

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }

        public List<Interview> Interviews { get; set; } = new List<Interview>();
    }
}