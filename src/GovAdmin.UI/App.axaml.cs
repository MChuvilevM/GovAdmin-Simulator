using Avalonia;
using Avalonia.Markup.Xaml;

namespace GovAdmin.UI;

public partial class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);
}
