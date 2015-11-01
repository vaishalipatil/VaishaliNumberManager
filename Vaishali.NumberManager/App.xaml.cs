using System;
using System.Windows;
using Microsoft.Practices.Unity;
using Vaishali.DataAccess;
using Vaishali.DataAccess.FileStorage;
using Vaishali.DataModel;
using Vaishali.NumberManager.Service;
using Vaishali.NumberManager.ViewModel;

namespace Vaishali.NumberManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            try
            {
                container.RegisterType<Number>();
                container.RegisterType<NumberService>();
                container.RegisterType<IDataConnection, FileOperations>();
                container.RegisterType<INumberViewModel, NumberViewModel>();
                container.Resolve<NumberService>();
                container.Resolve<NumberViewModel>();
                container.Resolve<MainWindow>().Show();
            }
            catch (System.NullReferenceException ex)
            {
                
            }
        }
    }
}
