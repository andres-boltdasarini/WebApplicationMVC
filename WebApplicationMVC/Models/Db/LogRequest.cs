using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMVC.Models.Db
{
    [Table("LogRequests")]
    public class LogRequest
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
