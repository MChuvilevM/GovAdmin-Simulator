using Avalonia.Controls;
using Avalonia.Interactivity;
using GovAdmin.Engine;
using GovAdmin.Core.Models;
using GovAdmin.Core.Services;
using System;

namespace GovAdmin.UI;

public partial class MainWindow : Window
{
    private readonly ScriptExecutor _executor = new();
    private readonly TicketGenerator _generator = new();
    private Ticket? _currentTicket;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void GenerateButton_Click(object sender, RoutedEventArgs e)
    {
        try {
            _currentTicket = _generator.Generate();
            var titleBlock = this.FindControl<TextBlock>("TicketTitle");
            if (titleBlock != null) 
                titleBlock.Text = $"[{_currentTicket.Priority}] {_currentTicket.Title}";
        } catch (Exception ex) {
            var output = this.FindControl<TextBlock>("OutputText");
            if (output != null) output.Text = "GEN_ERR: " + ex.Message;
        }
    }

    private void ExecuteButton_Click(object sender, RoutedEventArgs e)
    {
        var input = this.FindControl<TextBox>("ScriptInput");
        var output = this.FindControl<TextBlock>("OutputText");
        
        if (_currentTicket == null) {
            if (output != null) output.Text = "Error: Generate ticket first.";
            return;
        }

        try {
            var result = _executor.ExecuteTicketScript(input?.Text ?? "", _currentTicket);
            if (output != null) 
                output.Text = result.IsResolved ? $"SUCCESS: {result.Output}" : $"FAIL: {result.Output}";
        } catch (Exception ex) {
            if (output != null) output.Text = "EXEC_ERR: " + ex.Message;
        }
    }
}
