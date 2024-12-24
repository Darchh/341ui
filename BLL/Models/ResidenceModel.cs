using BLL.DAL;

namespace BLL.Models
{
    public class ResidenceModel
    {
        public Residence Record { get; set; }

        public string District => Record.District;

        public string Street => Record.Street;

        public string IsAvailable => Record.IsAvailable ? "Yes" : "No";

        public string Price => Record.Price.ToString();

    }
}
