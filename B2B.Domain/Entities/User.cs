using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        
        protected User() { }

        
        public User(string name, string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name can not be empty.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                throw new ArgumentException("Incoreccted format email.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Hash can not be empty.");

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }

        
        public void UpdateEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail) || !newEmail.Contains('@'))
                throw new ArgumentException("Incoreccted format email.");

            Email = newEmail;
        }

        public void ChangePassword(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new ArgumentException("New password hash required.");

            PasswordHash = newPasswordHash;
        }
    }
}
