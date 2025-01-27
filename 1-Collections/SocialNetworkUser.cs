using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    /// <inheritdoc cref="ISocialNetworkUser{TUser}"/>
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private readonly IDictionary<string, ISet<TUser>> _followedUsers = new Dictionary<string, ISet<TUser>>();

        /// <summary>
        /// Build a new <see cref="SocialNetworkUser{TUser}"/> class.
        /// </summary>
        /// <param name="fullName">The first plus last name of the user, it could be <c>null</c>.</param>
        /// <param name="username">The username of this user, cannot be <c>null</c>.</param>
        /// <param name="age">The age of the user, it could be <c>null</c>.</param>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="username"/> is <c>null</c>.</exception>
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
        }

        /// <inheritdoc cref="ISocialNetworkUser{TUser}.AddFollowedUser(string, TUser)"/>
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

        /// <inheritdoc cref="ISocialNetworkUser{TUser}.FollowedUsers"/>
        public IList<TUser> FollowedUsers => this._followedUsers.Values
                                                                .Aggregate(new List<TUser>(), (list, set) => {
                                                                    list.AddRange(set);
                                                                    return list;
                                                                });

        /// <inheritdoc cref="ISocialNetworkUser{TUser}.GetFollowedUsersInGroup(string)"/>
        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            var ret = new List<TUser>();
            if (this._followedUsers.ContainsKey(group)) ret.AddRange(this._followedUsers[group]);
            return ret;
        }
    }
}
