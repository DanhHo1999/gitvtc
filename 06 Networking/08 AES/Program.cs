using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace _08_AES
{
    class TestAES
    {

        public static class GlobalKey {
            public const String STRING_PERMUTATION = "sinhnx.dev";
            public const Int32 BYTE_PERMUTATION_1 = 0x19;
            public const Int32 BYTE_PERMUTATION_2 = 0x59;
            public const Int32 BYTE_PERMUTATION_3 = 0x17;
            public const Int32 BYTE_PERMUTATION_4 = 0x41;
        }

        //encoding

        public static string Encrypt(string strData) { }

        //decoding

        //encrypt

        public static byte[] Encrypt(byte[] byteData) {
            PasswordDeriveBytes passbyte = new PasswordDeriveBytes(
                GlobalKey.STRING_PERMUTATION,
                new byte[] {    GlobalKey.BYTE_PERMUTATION_1,
                                GlobalKey.BYTE_PERMUTATION_2,
                                GlobalKey.BYTE_PERMUTATION_3,
                                GlobalKey.BYTE_PERMUTATION_4});
            MemoryStream memoryStream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbyte.GetBytes(aes.KeySize/8);
            aes.IV = passbyte.GetBytes(aes.BlockSize/8);

            CryptoStream cryptoStream = new CryptoStream(
                memoryStream,
                aes.CreateEncryptor(),
                CryptoStreamMode.Write);
            cryptoStream.Write(byteData, 0, byteData.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }

        //decrypt

        public static byte[] Decrypt(byte[] byteData) {
            PasswordDeriveBytes passbyte = new PasswordDeriveBytes(
                GlobalKey.STRING_PERMUTATION,
                new byte[] {    GlobalKey.BYTE_PERMUTATION_1,
                                GlobalKey.BYTE_PERMUTATION_2,
                                GlobalKey.BYTE_PERMUTATION_3,
                                GlobalKey.BYTE_PERMUTATION_4});
            MemoryStream memoryStream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbyte.GetBytes(aes.KeySize / 8);
            aes.IV = passbyte.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptoStream = new CryptoStream(
                memoryStream,
                aes.CreateDecryptor(),
                CryptoStreamMode.Write);
            cryptoStream.Write(byteData, 0, byteData.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }
        
        static void Main(string[] args)
        {

        }
    }
}