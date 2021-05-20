using System.Windows;
using System.Security.Permissions;
using ST_HMI;
using ST_HMI.Services;
using Microsoft.AspNetCore.Authorization;

namespace ST_HMI
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    [Authorize(Roles = "Administrator")]
    public partial class AdminWindow : Window, IView
    {
        public AdminWindow()
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