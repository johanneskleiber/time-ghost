using System;

using time_ghost_app.ViewModels;

using Windows.UI.Xaml.Controls;

namespace time_ghost_app.Views
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
