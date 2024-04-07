using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Domain.Core.Extension
{
    public static class CriptografarExtension
    {
        public static string HashSHA256(this string plainText)
        {
            SHA256 criptoProvider = SHA256.Create();
            byte[] btexto = Encoding.UTF8.GetBytes(plainText);
            var criptoResultado = criptoProvider.ComputeHash(btexto);
            return Convert.ToHexString(criptoResultado);
        }
    }
}