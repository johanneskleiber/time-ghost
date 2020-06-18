using System;
using System.Collections.Generic;
using Prism.Windows.Mvvm;
using time_ghost.Core.Models;

namespace time_ghost.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public List<Timer> MondayTimers { get; private set; }

        public MainViewModel()
        {
            this.MondayTimers = new List<Timer>
            {
                new Timer() { Description = "Hello Timer 1" },
                new Timer() { Description = "Hello Timer 2" },
                new Timer() { Description = "Hello Timer 3" },
                new Timer() { Description = "Hello Timer 4" }
            };
        }
    }
}
