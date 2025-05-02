using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLoginFlow.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public Command LoginCommand { get; set; }
        public Command LogoutCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(() =>
            {
                if (LoginService.Login())
                {
                    Shell.Current.GoToAsync($"..", true);                   
                }               
            } , () => IsLogged == false);

            LogoutCommand = new Command(() =>
            {
                if (LoginService.Logout())
                {
                    Shell.Current.GoToAsync($"..", true); 
                }
            }, () => IsLogged);
        }
    }
}
