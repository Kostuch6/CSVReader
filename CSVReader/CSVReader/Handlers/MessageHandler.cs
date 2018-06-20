using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVReader.Handlers
{
    public static class MessageHandler
    {
        public static void ShowError(Exception ex)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            var result = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Błąd!", buttons);            
        }

        public static void ShowError(string error)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            var result = MessageBox.Show(error, "Błąd!", buttons);
        }

        public static void ShowMessage(string caption, string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            var result = MessageBox.Show(message, caption, buttons);
        }

        public static bool ShowMessageQuestion(string caption, string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            if (MessageBox.Show(message, caption, buttons) == DialogResult.Yes)
                return true;
            else
                return false;
        }
    }
}
