using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _PDSC_Web.Function
{
    public class EncryptionExtensions
    {
        // set permutations
        public const String strPermutation = "hitachi.ele";
        public const Int32 bytePermutation1 = 0x45;
        public const Int32 bytePermutation2 = 0x46;


        // encoding
        public string Encrypt(string strData)
        {

            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));

        }


        // decoding
        public string Decrypt(string strData)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));

        }

        //encrypt
        public static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] {bytePermutation1
                , bytePermutation2
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        // decrypt
        public static byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] { bytePermutation1
                , bytePermutation2
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
    }
}