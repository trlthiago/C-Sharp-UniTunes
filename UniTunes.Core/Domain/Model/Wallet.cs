using UniTunes.Core.Domain.Shared;

namespace UniTunes.Core.Domain.Model
{
    public class Wallet : Entity
    {
        public User Owner { get; private set; }
        public decimal CurrentValue { get; private set; }

        protected Wallet()
        {
            //EF
        }

        public Wallet(User user)
        {
            Owner = user;
            CurrentValue = 0;
        }

        public void AddCredit(decimal value)
        {
            CurrentValue += value;
        }
    }
}
