using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class InterviewModel
    {
        public Interview Record { get; set; }

        public string Date => Record.Date.ToString("MM/dd/yyyy") ?? string.Empty;

        public string Customer => string.Join("<br>", Record.Customer?.Name + " " + Record.Customer?.Surname);

        public string Agent => string.Join("<br>", Record.Agent?.Name + " " + Record.Agent?.Surname);

        public string Sale => Record.Sale?.Id.ToString();
    }
}


