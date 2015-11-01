using System.Windows;
using Microsoft.Practices.Unity;
using Vaishali.NumberManager.ViewModel;

namespace Vaishali.NumberManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(INumberViewModel numberViewModel):this()
        {
            DataContext = numberViewModel;
        }
    }
}
