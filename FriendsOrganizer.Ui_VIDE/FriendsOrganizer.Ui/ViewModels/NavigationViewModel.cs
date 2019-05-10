using DataAccess;
using FriendsOrganizer.Ui.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendsOrganizer.Ui.ViewModels
{
   public  class NavigationViewModel:ViewModelBase,INavigationViewModel
    {
        private List<Friend> _friends;
  
        public List<Friend> Friends
        {
            get { return _friends; }
            set {
                _friends = value;
                OnPropertyChanged();
            }
        }

        
        private IFriendsRepository _repository;
        private IEventAggregator _eventAggregator;
        private Friend _selectedFriend;

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                if (_selectedFriend != null)
                {
                    _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(_selectedFriend.Id);
                }

            }
        }
        public NavigationViewModel(IFriendsRepository repository, IEventAggregator eventAggregator)
        {
            _repository = repository;
            Friends = _repository.GetFriends();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<UpdateFriendDetailViewEvent>().Subscribe(onUpdateDetailView);
        }

        private void onUpdateDetailView()
        {
            Friends = _repository.GetFriends();
        }

        //private void Load(int friendId)
        //{
        //    SelectedFriend = _repository.GetFriendById(friendId);
        //}
        //public void Load()
        //{
        //    Friends = _repository.GetFriends();
        //}


    }
}
