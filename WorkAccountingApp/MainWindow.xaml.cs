using System.Windows;
using WorkAccountingApp.Models;
using WorkAccountingApp.Utility;
using WorkAccountingApp.ViewModels;

namespace WorkAccountingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AccountingViewModel(
                new DialogService(), 
                new JsonFileService<SelectedInformation>());
        }
    }
}
