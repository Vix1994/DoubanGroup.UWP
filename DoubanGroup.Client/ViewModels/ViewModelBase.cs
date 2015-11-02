﻿using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DoubanGroup.Core.Api;
using Windows.UI.Popups;

namespace DoubanGroup.Client.ViewModels
{
    public abstract class ViewModelBase : Prism.Windows.Mvvm.ViewModelBase
    {
        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { this.SetProperty(ref _isLoading, value); }
        }

        protected INavigationService NavigationService
        {
            get
            {
                return App.Current.Container.Resolve<INavigationService>();
            }
        }

        private static ApiClient CreateApiClient()
        {
            return App.Current.Container.Resolve<ApiClient>();
        }

        private Lazy<ApiClient> _apiClient = new Lazy<ApiClient>(CreateApiClient);

        protected ApiClient ApiClient
        {
            get
            {
                return _apiClient.Value;
            }
        }

        public virtual void Alert(string content, string title = null)
        {
            MessageDialog dialog;

            if (title == null)
            {
                dialog = new MessageDialog(content);
            }
            else
            {
                dialog = new MessageDialog(content, title);
            }
            dialog.ShowAsync();
        }
    }
}
