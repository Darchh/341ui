using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class InterviewModel
    {
        public Interview Record { get; set; }

        public string Date => Record.Date.ToString("MM/dd/yyyy") ?? string.Empty;

        public string Customer => Record.Customer?.Name ?? "N/A";

        public string Agent => Record.Agent?.Name ?? "N/A";

        public string Sale => Record.Sale?.Id.ToString() ?? "N/A";
    }
}
