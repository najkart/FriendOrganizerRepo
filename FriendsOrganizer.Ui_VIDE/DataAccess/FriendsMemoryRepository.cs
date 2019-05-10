
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FriendsMemoryRepository /*: IFriendsRepository*/
    {
        public List<Friend> GetFriends()
        {
            List<Friend> results = new List<Friend>();
            results.Add(new Friend { Id=1, Email = "toto@yopmail.com", FirstName = "Thomas", LastName = "Blot"});
            results.Add(new Friend { Id = 1, Email = "toto2@yopmail.com", FirstName = "Marc", LastName = "Gerard" });
            results.Add(new Friend { Id = 1, Email = "toto3@yopmail.com", FirstName = "Anthony", LastName = "Hopkins" });
            results.Add(new Friend { Id = 1, Email = "toto4@yopmail.com", FirstName = "Cyrielle", LastName = "Bernard" });

            return results;

        }

    }
}
