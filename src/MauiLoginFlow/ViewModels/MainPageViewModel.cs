using MauiLoginFlow.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLoginFlow.ViewModels
{
    public class MainPageViewModel: ViewModelBase
    {
        public Command GoToLoginCommand { get; set; }

        public MainPageViewModel()
        {
            GoToLoginCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);
                
            });
        }
    }
}
