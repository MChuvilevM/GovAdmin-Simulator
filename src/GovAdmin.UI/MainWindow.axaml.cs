using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading; // Добавь для безопасности потоков
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
            // Явный поиск через NameScope
            var titleBlock = this.FindNameScope()?.Find("TicketTitle") as TextBlock;
            
            if (titleBlock != null) 
                titleBlock.Text = $"[{_currentTicket?.Priority}] {_currentTicket?.Title ?? "None"}";
        } catch (Exception ex) {
            UpdateOutput($"GEN_ERR: {ex.GetType().Name}");
        }
    }

    private void ExecuteButton_Click(object sender, RoutedEventArgs e)
    {
        var input = this.FindNameScope()?.Find("ScriptInput") as TextBox;
        
        if (_currentTicket == null) {
            UpdateOutput("Error: Generate ticket first.");
            return;
        }

        try {
            var result = _executor.ExecuteTicketScript(input?.Text ?? "", _currentTicket);
            UpdateOutput(result.IsResolved ? $"SUCCESS: {result.Output}" : $"FAIL: {result.Output}");
        } catch (Exception ex) {
            UpdateOutput($"EXEC_ERR: {ex.GetType().Name}");
        }
    }

    private void UpdateOutput(string text)
    {
        Dispatcher.UIThread.InvokeAsync(() => {
            var output = this.FindNameScope()?.Find("OutputText") as TextBlock;
            if (output != null) output.Text = text;
        });
    }
}
