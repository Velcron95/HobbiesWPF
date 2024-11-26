using Hobbies.VM;
using System.Windows;

namespace Hobbies
{
    public partial class MainWindow : Window
{
    private HobbiesViewModel viewModel;

    public MainWindow()
    {
        InitializeComponent();
        viewModel = new HobbiesViewModel();
        DataContext = viewModel;
    }
}
}
