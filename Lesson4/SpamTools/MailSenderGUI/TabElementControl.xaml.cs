using System;
using System.Collections.Generic;
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

namespace MailSenderGUI
{
    /// <summary>
    /// Логика взаимодействия для TabElementControl.xaml
    /// </summary>
    public partial class TabElementControl : UserControl
    {
        public event EventHandler OnPrevButtonPressed;
        public event EventHandler OnNextButtonPressed;

        public TabElementControl()
        {
            InitializeComponent();
        }

        private void OnButtonclick(object Sender, RoutedEventArgs E)
        {
            if(!(Sender is Button button)) return;

            if(button.Content as string == "Назад")
                OnPrevButtonPressed?.Invoke(this, EventArgs.Empty);

            if(button.Content as string == "Вперёд")
                OnNextButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
