using DataAccess;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class MainViewModel
    {
   public IFriendDetailViewModel FriendDetail { get; set; }
        public INavigationViewModel NavigationVM { get; }
        public MainViewModel(INavigationViewModel navigationVM , IFriendDetailViewModel friendDetail )
        {
            NavigationVM = navigationVM;
            FriendDetail = friendDetail;

        }
    }
}
