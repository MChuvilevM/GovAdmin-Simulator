using Avalonia.Controls;
using Avalonia.Interactivity;
using GovAdmin.Engine;
using GovAdmin.Core.Models;
using GovAdmin.Core.Services;

namespace GovAdmin.UI;

public partial class MainWindow : Window
{
    private readonly ScriptExecutor _executor = new();
    private readonly TicketGenerator _generator = new();
    private Ticket? _currentTicket;

    public MainWindow() => InitializeComponent();

    private void GenerateButton_Click(object sender, RoutedEventArgs e)
    {
        _currentTicket = _generator.Generate();
        TicketTitle.Text = $"[{_currentTicket.Priority}] {_currentTicket.Title}";
    }

    private void ExecuteButton_Click(object sender, RoutedEventArgs e)
    {
        if (_currentTicket == null) return;
        
        var result = _executor.ExecuteTicketScript(ScriptInput.Text ?? "", _currentTicket);
        OutputText.Text = result.IsResolved ? $"SUCCESS: {result.Output}" : $"FAIL: {result.Output}";
    }
}
