using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SpamLib;
using SpamLib.Data;

namespace MailSenderGUI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataAccessService _DataAccessService;

        private string _Title = "Заголовок окна";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private ObservableCollection<Recipient> _Recipients;
        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        private Recipient _CurrentRecipient = new Recipient();
        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }

        #region Emails : ObservableCollection<Email> - Сообщения

        /// <summary>Сообщения</summary>
        private ObservableCollection<Email> _Emails;

        /// <summary>Сообщения</summary>
        public ObservableCollection<Email> Emails
        {
            get => _Emails;
            set => Set(ref _Emails, value);
        }

        #endregion

        #region SelectedEmail : Email - Выбранное сообщение

        /// <summary>Выбранное сообщение</summary>
        private Email _SelectedEmail;

        /// <summary>Выбранное сообщение</summary>
        public Email SelectedEmail
        {
            get => _SelectedEmail;
            set => Set(ref _SelectedEmail, value);
        }

        #endregion


        public ICommand UpdateDataCommand { get; }

        public ICommand CreateNewRecipient { get; }
        public ICommand UpdateRecipient { get; }

        public ICommand AddNewEmailCommand { get; }
        public ICommand RemoveEmailCommand { get; }

        public MainWindowViewModel(IDataAccessService DataAccessService)
        {
            _DataAccessService = DataAccessService;

            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, UpdateDataCommandCanExecute);

            CreateNewRecipient = new RelayCommand(OnCreateNewRecipientExecuted);
            UpdateRecipient = new RelayCommand<Recipient>(OnUpdateRecepientExecuted, UpdateRecepientCanExecute);

            AddNewEmailCommand = new RelayCommand(OnAddNewEmailCommandExecuted);
            RemoveEmailCommand = new RelayCommand<object>(OnRemoveEmailCommandExecuted, RemoveEmailCommandCanExecute);

            InitializeAsync();
        }

        private bool RemoveEmailCommandCanExecute(object Arg) => Arg is Email || Arg is IList list && list.Count > 0;

        private async void OnRemoveEmailCommandExecuted(object Obj)
        {
            switch (Obj)
            {
                case Email email:
                    //if (await _DataAccessService.RemoveEmailAsync(email))
                    Emails.Remove(email);
                    break;
                case IList email_list:
                    foreach (var email in email_list.OfType<Email>().ToArray())
                        //if (await _DataAccessService.RemoveEmailAsync(email))
                        Emails.Remove(email);
                    break;
            }
        }

        private async void OnAddNewEmailCommandExecuted()
        {
            var new_email = new Email
            {
                Title = "Заголовок письма",
                Body = ""
            };
            if (await _DataAccessService.AddNewEmailAsync(new_email))
                Emails.Add(new_email);
        }

        private async void InitializeAsync()
        {
            if (IsInDesignMode) return;

            Recipients = await _DataAccessService.GetRecipientsAsync();
            Emails = await _DataAccessService.GetEmailsAsync();
            //SelectedEmail = Emails.FirstOrDefault();
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
            //if(_DataAccessService.CreateRecipient(recipient) > 0)
            //    Recipients.Add(recipient);
        }
    }
}
