using System;
using System.Collections.Generic;
using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Domain.Model
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public UserStatus Status { get; private set; }
        public string RecoveryPasswordHash { get; private set; }
        public bool IsAdministrator { get; private set; }//Just a flag. either it is or dont.
        public List<Purchase> Purchases { get; set; }

        protected User()
        {
            //EF
            Purchases = new List<Purchase>();
        }

        public User(string name, string email, string password) : this()
        {
            Name = name;
            email = Email;

            //o mínimo 6 e no máximo 30 caracteres alfanuméricos
            if (password.Length <= 6 || password.Length > 30)
                throw new ArgumentException("the password must be longer than 6 and shorter than 30 chars.");

            Password = password;

            Activate();
        }

        public void Deactivate()
        {
            Status = UserStatus.Deactivated;
        }

        public void Activate()
        {
            Status = UserStatus.Active;
        }

        public void Block()
        {
            Status = UserStatus.Blocked;
        }
    }

    public enum UserStatus
    {
        PendingAproval = 1,
        Active = 2,
        Blocked = 3,
        Deactivated = 4
    }
}
