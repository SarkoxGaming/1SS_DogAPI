using ApiHelper;
using DogFetchApp.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogFetchApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public DelegateCommand<string> RestartCommand { get; set; }

        public DelegateCommand<string> ChangeLanguageCommand { get; set; }

        public MainViewModel()
        {
            ChangeLanguageCommand = new DelegateCommand<string>(ChangeLanguage);

        }
        private void ChangeLanguage(string param)
        {
            Properties.Settings.Default.Language = param;
            Properties.Settings.Default.Save();

            RestartCommand?.Execute("");
        }

        private List<string> breeds;

        public List<string> Breeds
        {
            get { return breeds; }
            set
            {
                breeds = value;
                OnPropertyChanged();
            }
        }

        private DogModel dogs;

        public DogModel Dogs
        {
            get { return dogs; }
            set
            {
                dogs = value;
                OnPropertyChanged();
            }
        }

    }
}
