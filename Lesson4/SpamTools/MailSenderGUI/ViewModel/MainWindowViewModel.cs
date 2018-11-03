using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SpamLib;

namespace MailSenderGUI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataAccessService _DataAccessService;

        private string _Title = "Mail Sender";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public ObservableCollection<Recipient> Recipients { get; private set; }

        private Recipient _CurrentRecipient = new Recipient();

        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }

        public ICommand UpdateDataCommand { get; }

        public ICommand CreateNewRecipient { get; }
        public ICommand UpdateRecipient { get; }

        public MainWindowViewModel(IDataAccessService DataAccessService)
        {
            _DataAccessService = DataAccessService;
            Recipients = _DataAccessService.GetRecipients();

            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, UpdateDataCommandCanExecute);

            CreateNewRecipient = new RelayCommand(OnCreateNewRecipientExecuted);
            UpdateRecipient = new RelayCommand<Recipient>(OnUpdateRecepientExecuted, UpdateRecepientCanExecute);
        }

        public bool UpdateDataCommandCanExecute() => true;

        private void OnUpdateDataCommandExecuted()
        {
            Recipients = _DataAccessService.GetRecipients();
            RaisePropertyChanged(nameof(Recipients));
        }

        private void OnCreateNewRecipientExecuted()
        {
            CurrentRecipient = new Recipient();
        }

        private bool UpdateRecepientCanExecute(Recipient recipient) => recipient != null;// || _CurrentRecipient != null;

        private void OnUpdateRecepientExecuted(Recipient recipient)
        {
            if(_DataAccessService.CreateRecipient(recipient) > 0)
                Recipients.Add(recipient);
        }
    }
}
