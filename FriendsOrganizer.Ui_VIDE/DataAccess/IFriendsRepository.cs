
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IFriendsRepository
    {
        List<Friend> GetFriends() ;
        Friend GetFriendById(int friendId);
        void Save(Friend friend);
        void Delete(int friendId);
        void Insert(Friend friend);
    }
}
