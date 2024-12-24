using BLL.DAL;

namespace BLL.Models
{
    public class AgentModel
    {
        public Agent Record { get; set; }

        public string Name => Record.Name;

        public string Surname => Record.Surname;

        public string Email => Record.Email;

        public string Salary => Record.Salary.ToString();

        public string InterviewDates => Record.Interviews != null
            ? string.Join(", ", Record.Interviews.Select(i => i.Date.ToString("yyyy-MM-dd")))
            : "No interviews available";
    }
}
