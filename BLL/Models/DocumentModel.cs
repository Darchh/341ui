using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class DocumentModel
    {
        public Document Record { get; set; }

        public string Taxes => Record.Taxes.ToString();

        public string TitleDeed => Record?.TitleDeed?.ToString();

        public string Contract => Record?.Contract?.ToString();

        public string Residence => Record.Residence?.Street;

        public string Sale => Record.Sale?.Status;
    }
}