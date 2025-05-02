using CommunityToolkit.Mvvm.Messaging;
using MauiLoginFlow.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiLoginFlow.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public LoginService LoginService { get; private set; }

        public ViewModelBase()
        {
            LoginService = App.Current.Handler.MauiContext.Services.GetService<LoginService>();
            IsLogged = LoginService.IsLogged;
            WeakReferenceMessenger.Default.Register<AuthenticationMessage>(this, (r, m) =>
            {
                IsLogged = m.IsLogged;
            });

        }

        private bool isLogged;
        public bool IsLogged
        {
            get { return isLogged; }
            private set { SetProperty(ref isLogged, value); }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
