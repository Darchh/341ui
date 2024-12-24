using BLL.DAL;

namespace BLL.Models
{
    public class CustomerModel
    {
        public Customer Record { get; set; }

        public string Name => Record.Name;

        public string Surname => Record.Surname;

        public string Gender => Record.Gender;

        public string IsFamily => Record.IsFamily ? "Yes" : "No";

    }
}
