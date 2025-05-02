using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLoginFlow.Services
{
    public class LoginService
    {
        private bool isLogged;
        public bool IsLogged
        {
            get { return isLogged; }
            private set
            {
                isLogged = value;
                WeakReferenceMessenger.Default.Send<AuthenticationMessage>(new AuthenticationMessage
                {
                    IsLogged = value
                });
            }
        }

        public bool Login()
        {
            //Your logic
            IsLogged = true;
            return true;
        }

        public bool Logout()
        {
            //Your logic
            IsLogged = false;
            return true;
        }
    }

    public class AuthenticationMessage
    {
        public bool IsLogged { get; set; }
    }
}
