using BLL.DAL;

namespace BLL.Models
{
    public class SaleModel
    {
        public Sale Record { get; set; }

        public int SaleId => Record.Id;

        public string Status => Record.Status;

        public string Deposit => Record.Deposit.ToString();
        
    }
}
