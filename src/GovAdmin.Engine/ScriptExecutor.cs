using System.Management.Automation;
using GovAdmin.Core.Models;

namespace GovAdmin.Engine;

public class ScriptExecutor
{
    public string ExecuteTicketScript(string script, Ticket ticket)
    {
        using var ps = PowerShell.Create();
        ps.AddScript(script);
        ps.AddParameter("TicketId", ticket.Id);
        
        var results = ps.Invoke();
        return string.Join(Environment.NewLine, results.Select(r => r.ToString()));
    }
}
