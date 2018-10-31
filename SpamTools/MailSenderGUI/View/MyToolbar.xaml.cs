using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MyToolbar.xaml
    /// </summary>
    public partial class MyToolbar : UserControl
    {

        public MyToolbar()
        {
            InitializeComponent();
        }
        public string TextOfTextBlock
        {
            get => (string)GetValue(TextOfTextBlockProperty);
            set => SetValue(TextOfTextBlockProperty, value);
        }
        public static readonly DependencyProperty TextOfTextBlockProperty =
                                            DependencyProperty.Register("TextOfTextBlock",
                                            typeof(string), typeof(MyToolbar),
                                            new UIPropertyMetadata("Поле", new PropertyChangedCallback(TextOfTextBoxChanged)));

        public static void TextOfTextBoxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyToolbar myToolbar = (MyToolbar)d;
            TextBlock textBlock = myToolbar.mainTextBlock;
            textBlock.Text = e.NewValue.ToString();
        }

    }
}
