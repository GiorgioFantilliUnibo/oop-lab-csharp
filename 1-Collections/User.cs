using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            this.Username = username ?? throw new ArgumentNullException(nameof(username));
            this.FullName = fullName;
            this.Age = age;
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => throw new NotImplementedException("TODO check whether age is non-null or not");
        
        // TODO implement missing methods (try to autonomously figure out which are the necessary methods)
    }
}
