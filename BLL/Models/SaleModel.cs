using BLL.DAL;

namespace BLL.Models
{
    public class SaleModel
    {
        public Sale Record { get; set; }

        public string Status => Record.Status;

        public string Deposit => Record.Deposit.ToString();
    }
}
