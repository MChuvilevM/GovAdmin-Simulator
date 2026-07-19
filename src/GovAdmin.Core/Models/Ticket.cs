namespace GovAdmin.Core.Models;

public enum TicketPriority
{
    Critical,
    Routine,
    Absurd
}

public class Ticket
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; }
    public bool IsResolved { get; set; }
}
