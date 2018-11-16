using System;
using System.Collections;
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
    public class ItemsCollectionControl : Control
    {
        #region ItemSource : object - Элементы коллекции

        /// <summary>Элементы коллекции</summary>
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
                nameof(ItemSource),
                typeof(IEnumerable),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(IEnumerable), OnItemSourcePropertyChanged));

        private static void OnItemSourcePropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {
            
        }

        /// <summary>Элементы коллекции</summary>
        public IEnumerable ItemSource
        {
            get => (IEnumerable) GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }

        #endregion

        #region CreateCommand : ICommand - Команда создания объекта

        /// <summary>Команда создания объекта</summary>
        public static readonly DependencyProperty CreateCommandProperty =
            DependencyProperty.Register(
                nameof(CreateCommand),
                typeof(ICommand),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда создания объекта</summary>
        public ICommand CreateCommand
        {
            get => (ICommand) GetValue(CreateCommandProperty);
            set => SetValue(CreateCommandProperty, value);
        }

        #endregion

        #region DeleteCommand : ICommand - Команда удаления объекта

        /// <summary>Команда удаления объекта</summary>
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(
                nameof(DeleteCommand),
                typeof(ICommand),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда удаления объекта</summary>
        public ICommand DeleteCommand
        {
            get => (ICommand) GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        #endregion

        #region EditCommand : ICommand - Команда редактирования объекта

        /// <summary>Команда редактирования объекта</summary>
        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register(
                nameof(EditCommand),
                typeof(ICommand),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда редактирования объекта</summary>
        public ICommand EditCommand
        {
            get => (ICommand) GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }

        #endregion

        #region PanelName : string - Имя панели

        /// <summary>Имя панели</summary>
        public static readonly DependencyProperty PanelNameProperty =
            DependencyProperty.Register(
                nameof(PanelName),
                typeof(string),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(string)));

        /// <summary>Имя панели</summary>
        public string PanelName
        {
            get => (string) GetValue(PanelNameProperty);
            set => SetValue(PanelNameProperty, value);
        }

        #endregion

        #region SelectionIndex : int - Индекс выбранного элемента

        /// <summary>Индекс выбранного элемента</summary>
        public static readonly DependencyProperty SelectionIndexProperty =
            DependencyProperty.Register(
                nameof(SelectionIndex),
                typeof(int),
                typeof(ItemsCollectionControl),
                new PropertyMetadata(default(int)));

        /// <summary>Индекс выбранного элемента</summary>
        public int SelectionIndex
        {
            get => (int) GetValue(SelectionIndexProperty);
            set => SetValue(SelectionIndexProperty, value);
        }

        #endregion

        static ItemsCollectionControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ItemsCollectionControl), new FrameworkPropertyMetadata(typeof(ItemsCollectionControl)));
        }
    }
}
