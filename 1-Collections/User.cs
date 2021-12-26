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

        /// <summary>
        /// Get the string rappresentation of the generic user.
        /// </summary>
        /// <retuns>a string representing the user.</retuns>
        public override string ToString() => $"{nameof(User)}[{nameof(Username)}: {this.Username}, {nameof(FullName)}: {this.FullName}," +
                                             $" {nameof(Age)}: {this.Age}]";

        /// <summary>
        /// Determines whether two instances of the <see cref="IUser"/> interface are equal.
        /// </summary>
        /// <param name="other">the instances of <see cref="IUser"/> to compare.</param>
        /// <returns>true if the two instaces are equal, false otherwise</returns>
        public bool Equals(IUser other)
        {
            return this.Equals(other as User);
        }

        /// <summary>
        /// Determines whether two instances of the <see cref="User"/> class are equal.
        /// </summary>
        /// <param name="other">the instances of <see cref="User"/> to compare.</param>
        /// <returns>true if the two instaces are equal, false otherwise</returns>
        public bool Equals(User other)
        {
            return this == other || (this.Username.Equals(other.Username) &&
                                     this.FullName.Equals(other.FullName) &&
                                     this.Age.Equals(other.Age));
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as User);
        }

        /// <inheritdoc cref="object.GetHashCode()"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Username, this.FullName, this.Age);
        }
    }
}
