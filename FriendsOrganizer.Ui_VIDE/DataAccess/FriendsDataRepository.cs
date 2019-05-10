using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class FriendsDataRepository : IFriendsRepository
    {
        public void Delete(int friendId)
        {
            using (var context = new FriendsOrganizerDbEntities())
            {
              var result = context.Friends.FirstOrDefault(f => f.Id == friendId);
                context.Friends.Remove(result);
                context.SaveChanges();
            }
        }

        public Friend GetFriendById(int friendId)
        {
            using (var context = new FriendsOrganizerDbEntities())
            {
                return context.Friends.FirstOrDefault(f=> f.Id== friendId);
            }
        }

        public List<Friend> GetFriends()
        {
            using (var context = new FriendsOrganizerDbEntities())
            {
                return context.Friends.ToList();
            }
                
        }

        public void Insert(Friend friend)
        {
            using (var context = new FriendsOrganizerDbEntities())
            {
                context.Friends.Add(friend);
              
                context.SaveChanges();
            }
        }

        public void Save(Friend  friend)
        {
            using (var context = new FriendsOrganizerDbEntities())
            {
             
                var result = context.Friends.FirstOrDefault(f=> f.Id== friend.Id);
                result.FirstName = friend.FirstName;
                result.LastName = friend.LastName;
                result.Email = friend.Email;
                context.SaveChanges();
            }
        }
    }
}
