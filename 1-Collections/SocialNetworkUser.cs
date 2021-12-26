using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private readonly IDictionary<string, ISet<TUser>> _followedUsers = new Dictionary<string, ISet<TUser>>();

        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (this._followedUsers.ContainsKey(group))
            {
                return this._followedUsers[group].Add(user);
            }
            else
            {
                var set = new HashSet<TUser>();
                set.Add(user);
                this._followedUsers[group] = set;
                return true;
            }
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                throw new NotImplementedException("TODO construct and return the list of all users followed by the current users, in all groups");
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            throw new NotImplementedException("TODO construct and return a collection containing of all users followed by the current users, in group");
        }
    }
}
