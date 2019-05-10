using Autofac;
using DataAccess;
using FriendsOrganizer.Ui.StartUp;
using FriendsOrganizer.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FriendsOrganizer.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_startUp(object sender, StartupEventArgs e)
        {
            //var repository = new FriendsMemoryRepository();
            //var mainWindow = new MainWindow(new MainViewModel(repository));
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();
           var mainWindow = container.Resolve<MainWindow>();
       
            mainWindow.Show();
        }
    }
}
