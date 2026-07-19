using System.Management.Automation;
using GovAdmin.Core.Models;

namespace GovAdmin.Engine;

public class ScriptExecutor
{
    public (string Output, bool IsResolved) ExecuteTicketScript(string script, Ticket ticket)
    {
        using var ps = PowerShell.Create();
        ps.AddScript(script);
        ps.AddParameter("TicketId", ticket.Id);
        
        var results = ps.Invoke();
        var output = string.Join(Environment.NewLine, results.Select(r => r.ToString()));
        
        bool resolved = output.Contains("RESOLVED");
        if (resolved) ticket.IsResolved = true;
        
        return (output, resolved);
    }
}
