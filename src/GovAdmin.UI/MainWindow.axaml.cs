using Avalonia.Controls;
using GovAdmin.Engine;
using GovAdmin.Core.Models;

namespace GovAdmin.UI;

public partial class MainWindow : Window
{
    private readonly ScriptExecutor _executor = new();

    public MainWindow() => InitializeComponent();

    private void ExecuteButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var dummyTicket = new Ticket { Title = "Test" };
        OutputText.Text = _executor.ExecuteTicketScript(ScriptInput.Text ?? "", dummyTicket);
    }
}
