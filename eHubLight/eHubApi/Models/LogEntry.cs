using System.ComponentModel.DataAnnotations;

namespace eHubApi.Models;

public class LogEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Message { get; set; } = "?";

    public DateTime Created { get; set; } = DateTime.Now;
}
