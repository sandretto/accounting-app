using Microsoft.Win32;
using System.Windows;

namespace WorkAccountingApp.Utility
{
    public interface IDialogService
    {
        string FilePath { get; set; } 
        void ShowMessage(string message);
        bool SaveFileDialog();
    }

    public class DialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
