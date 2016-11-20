using System;
using System.Windows;
using Caliburn.Micro;

using OSIM.WinClient.ViewModels;

namespace OSIM.WinClient
{
    public class WinClientBootstrapper : BootstrapperBase
    {
        public WinClientBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<SearchViewModel>();
        }
    }
}
