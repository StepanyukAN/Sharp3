using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSenderGUI.View
{
    /// <summary>
    /// Логика взаимодействия для RecipientEditView.xaml
    /// </summary>
    public partial class RecipientEditView : UserControl
    {
        public RecipientEditView()
        {
            InitializeComponent();
        }

        private void OnRecepientID_ValidationError(object Sender, ValidationErrorEventArgs E)
        {
            if(!(Sender is Control control)) return;
            switch (E.Action)
            {
                case ValidationErrorEventAction.Added:
                    control.ToolTip = E.Error.ErrorContent.ToString();
                    break;
                case ValidationErrorEventAction.Removed:
                    control.ToolTip = "";
                    break;
            }    
        }
    }
}
