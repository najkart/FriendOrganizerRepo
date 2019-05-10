using DataAccess;
using FriendsOrganizer.Ui.Events;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendsOrganizer.Ui.ViewModels
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {


        private Friend _currentFriend = new Friend();
        private IFriendsRepository _repository;
    
        public Friend CurrentFriend
        {
            get { return _currentFriend; }
            set
            {
                if (_currentFriend != value)
                {
                    _currentFriend = value;
                    OnPropertyChanged();
                    
                    // [CallerMemberName] permet de récuperer la propriété sans la passer en parametre
                }

            }
        }

    
        private IEventAggregator _eventAggregator;
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand InsertCommand { get; set; }


        public void Load(int friendId)
        {
            CurrentFriend= _repository.GetFriendById(friendId);
        }
      
        public FriendDetailViewModel(IEventAggregator eventAggregator , IFriendsRepository repository )
        {
           
            _repository = repository;
             _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(onOpenFriendDetailView);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute, OnCanDeleteExecute);
            InsertCommand = new DelegateCommand(OnInsertExecute, OnCanInsertExecute);

        }

        private bool OnCanInsertExecute()
        {
            return true;
        }

        private void OnInsertExecute()
        {

            _repository.Insert(CurrentFriend);
            _eventAggregator.GetEvent<UpdateFriendDetailViewEvent>().Publish();
        }

        private void OnDeleteExecute()
        {
            _repository.Delete(CurrentFriend.Id);
            _eventAggregator.GetEvent<UpdateFriendDetailViewEvent>().Publish();
            CurrentFriend = new Friend();

        }

        private bool OnCanDeleteExecute()
        {
            return true;
        }

        private void OnSaveExecute()
        {

            _repository.Save(CurrentFriend);
            _eventAggregator.GetEvent<UpdateFriendDetailViewEvent>().Publish();
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private void onOpenFriendDetailView(int friendId)
        {
            Load(friendId);
        }
    }
    
}


