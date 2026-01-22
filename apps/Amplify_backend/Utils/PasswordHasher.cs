using System;
using System.Security.Cryptography;
using System.Text;

namespace Amplify_backend.Utils
{
    public static class PasswordHasher
    {
        private const int _iterations = 350000;
        private const int _keySize = 64; // 512 bits
        private const int _saltSize = 16; // 128 bits
        private static readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;
        private const char _delimiter = ';';

        public static string HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(_saltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                _iterations,
                _hashAlgorithm,
                _keySize
            );

            return string.Join(
                _delimiter,
                _iterations,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash)
            );
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            var parts = passwordHash.Split(_delimiter);

            if (parts.Length != 3)
            {
                return false;
            }

            var iterations = int.Parse(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var storedHash = Convert.FromBase64String(parts[2]);

            var newHash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                _hashAlgorithm,
                _keySize
            );

            return CryptographicOperations.FixedTimeEquals(storedHash, newHash);
        }
    }
}