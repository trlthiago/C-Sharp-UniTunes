namespace UniTunes.Core.Infra
{
    public interface ICrypto
    {
        string Encrypt(string plaintext);
        string Decrypt(string encryptedtext);
    }

    public class UnisinosCrypt : ICrypto
    {
        public string Decrypt(string encryptedtext)
        {
            return encryptedtext;
        }

        public string Encrypt(string plaintext)
        {
            return plaintext;
        }
    }
}
