using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace BeautySalon.Auth.BLL
{
    public interface IEncryptService
    {
        byte[] GenerateSalt();
        byte[] HashPassword(string password, byte[] salt);
    }
    public class EncryptService : IEncryptService
    {
        public byte[] GenerateSalt() => Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
        public byte[] HashPassword(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 512 / 32 // 512 bits (64 bytes)
                );
        }
    }
}
