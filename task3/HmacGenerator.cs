using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;


namespace task3
{
    public class HmacGenerator
    {
        private readonly byte[] _key;

        public HmacGenerator()
        {
            _key = new byte[32];
        }

        public void GenerateNewKey()
        {
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(_key);
        }

        public string GenerateHmac(string move)
        {
            using var hmac = new HMACSHA256(_key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(move);
            byte[] hashBytes = hmac.ComputeHash(messageBytes);
            return HashToHex(hashBytes);
        }

        public string GetKey()
        {
            return HashToHex(_key);
        }

        private String HashToHex(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "");
        } 
    }
}