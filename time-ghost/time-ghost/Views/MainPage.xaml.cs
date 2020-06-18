using System;

using time_ghost.ViewModels;

using Windows.UI.Xaml.Controls;

namespace time_ghost.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
