using System;

namespace Collections
{
    /// <summary>
    /// Represent a generic user.
    /// </summary>
    public class User : IUser
    {
        /// <summary>
        /// Build a new <see cref="User"/> class.
        /// </summary>
        /// <param name="fullName">The first plus last name of the user, it could be <c>null</c>.</param>
        /// <param name="username">The username of this user, cannot be <c>null</c>.</param>
        /// <param name="age">The age of the user, it could be <c>null</c>.</param>
        public User(string fullName, string username, uint? age)
        {
            this.Username = username ?? throw new ArgumentNullException(nameof(username));
            this.FullName = fullName;
            this.Age = age;
        }

        /// <inheritdoc cref="IUser.Age"/>
        public uint? Age { get; }

        /// <inheritdoc cref="IUser.FullName"/>
        public string FullName { get; }

        /// <inheritdoc cref="IUser.Username"/>
        public string Username { get; }

        /// <inheritdoc cref="IUser.IsAgeDefined"/>
        public bool IsAgeDefined => this.Age != null;
        
    }
}
