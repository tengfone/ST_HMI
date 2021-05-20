using System.Windows;
using System.Security.Permissions;
using ST_HMI.Services;
using System;
using Microsoft.AspNetCore.Authorization;

namespace ST_HMI
{
    /// <summary>
    /// Interaction logic for SecretWindow.xaml
    /// </summary>
    [Authorize()]
    public partial class SecretWindow : Window, IView
    {
        public SecretWindow()
        {
            InitializeComponent();
        }

        #region IView Members

        public IViewModel ViewModel
        {
            get
            {
                return DataContext as IViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        #endregion
    }
}