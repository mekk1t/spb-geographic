using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace SUAI.SpbGeographic.Trainer.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Получает хэш пароля, используя алгоритм PBKDF2. Реализация взята из документации Microsoft.
        /// </summary>
        public static string Hash(this string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hash;
        }
    }
}
