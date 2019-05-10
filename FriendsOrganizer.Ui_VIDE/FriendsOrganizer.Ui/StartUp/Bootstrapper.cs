using Autofac;
using DataAccess;
using FriendsOrganizer.Ui.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOrganizer.Ui.StartUp
{
    class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<FriendsDataRepository>().As<IFriendsRepository>();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            // SingleInstance() permet d'instancier une seule fois 

            return builder.Build();
        }
    }
}
