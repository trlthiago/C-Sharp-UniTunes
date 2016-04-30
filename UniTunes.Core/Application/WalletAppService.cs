using System.Linq;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra.Database;
using UniTunes.Core.Infra.Billing;

namespace UniTunes.Core.Application
{
    public class WalletAppService
    {
        private IDbContext _ctx;
        private CardOperatorFactory _factory;

        public WalletAppService(IDbContext ctx)
        {
            _ctx = ctx;
            _factory = new CardOperatorFactory();
        }

        public void AddCredit(int userId, string cardNumber, int verificationCode, string name, CardFlag flag, decimal value)
        {
            _factory.GetInstance(flag).Debit(name, cardNumber, verificationCode, value);
            var wallet = GetOrCreateWallet(userId);
            wallet.AddCredit(value);
            _ctx.SaveChanges();
        }

        public void AddCredit(string barcode)
        {
            throw new System.NotImplementedException();
        }

        public void AddCredit(string accountNumber, string agency)
        {
            throw new System.NotImplementedException();
        }

        private Wallet GetOrCreateWallet(int userId)
        {
            var wallet = _ctx.Wallets.FirstOrDefault(x => x.Owner.Id == userId);
            if (wallet == null)
            {
                var user = _ctx.Users.Find(userId);
                wallet = new Wallet(user);
                _ctx.Wallets.Add(wallet);
            }

            return wallet;
        }
    }
}
