using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTunes.Core.Domain.Model;

namespace UniTunes.Core.Infra.Billing
{
    public interface ICardOperator
    {
        void Debit(string name, string cardNumber, int verificationCode, decimal value);
        void Refound(string name, string cardNumber, int verificationCode, decimal value);
    }

    public class Visa : ICardOperator
    {
        public void Debit(string name, string cardNumber, int verificationCode, decimal value)
        {
            throw new NotImplementedException();
        }

        public void Refound(string name, string cardNumber, int verificationCode, decimal value)
        {
            throw new NotImplementedException();
        }
    }

    public class Master : ICardOperator
    {
        public void Debit(string name, string cardNumber, int verificationCode, decimal value)
        {
            throw new NotImplementedException();
        }

        public void Refound(string name, string cardNumber, int verificationCode, decimal value)
        {
            throw new NotImplementedException();
        }
    }

    public class CardOperatorFactory
    {
        public ICardOperator GetInstance(CardFlag flag)
        {
            switch (flag)
            {
                case CardFlag.Visa:
                    return new Visa();
                case CardFlag.Master:
                    return new Master();
                default:
                    throw new ArgumentOutOfRangeException(nameof(flag));
            }
        }
    }
}
