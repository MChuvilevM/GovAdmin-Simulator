using Xunit;
using GovAdmin.Engine;
using GovAdmin.Core.Models;

namespace GovAdmin.Tests;

public class ExecutorTests
{
    [Fact]
    public void Test_Resolution_Logic()
    {
        var executor = new ScriptExecutor();
        var ticket = new Ticket { Title = "Test" };
        
        var result = executor.ExecuteTicketScript("Write-Output 'RESOLVED'", ticket);
        
        Assert.True(result.IsResolved);
        Assert.True(ticket.IsResolved);
    }
}
