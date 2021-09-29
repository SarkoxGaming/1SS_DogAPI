using DogFetchApp.Commands;
using DogFetchApp.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;

namespace DogFetchApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm;
        App app;

        public MainWindow(App app)
        {
            InitializeComponent();
            ApiHelper.ApiHelper.InitializeClient();
            vm = new MainViewModel();
            DataContext = vm;

            this.app = app;

            NextButton.IsEnabled = false;
            PreviousButton.IsEnabled = false;
            vm.RestartCommand = new DelegateCommand<string>(Restart);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ApiHelper.BreedModel breeds = await ApiHelper.DogApiProcessor.LoadBreedList();
            vm.Breeds = breeds.getAllBread();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string selectBreed = breed.SelectedItem.ToString().ToLower();

            string breedMessage = Regex.Replace(selectBreed.Split()[0], @"[^0-9a-zA-Z\ ]+", "");

            string comboNbPhoto = nbPhoto.SelectedValue.ToString().Substring(nbPhoto.SelectedValue.ToString().Length - 2);
            int nbPhotoint = int.Parse(comboNbPhoto);

            vm.Dogs = await ApiHelper.DogApiProcessor.GetImageUrl(breedMessage, nbPhotoint);
            NextButton.IsEnabled = true;
        }

        

        private void Restart(string obj)
        {
            var toWhichLanguage = DogFetchApp.Properties.Settings.Default.Language;

            string content;

            if (toWhichLanguage == "fr")
            {
                content = "Pour appliquer les changements, il faut redémarrer l'application.";
            }
            else if (toWhichLanguage == "en")
            {
                content = "To apply the changes, you must restart the application.";
            }
            else
            {
                content = "error language";
            }

            var result = MessageBox.Show(content, "Message", MessageBoxButton.OKCancel);
            
            
            if (result == MessageBoxResult.OK)
            {
                app.Restart();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PreviousButton.IsEnabled = true;
            vm.Dogs.next();
            vm.Dogs = vm.Dogs;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            vm.Dogs.previous();
            if (vm.Dogs.MinDog <= 0)
                PreviousButton.IsEnabled = false;
            else
                PreviousButton.IsEnabled = true;
            vm.Dogs = vm.Dogs;
        }
    }
}
