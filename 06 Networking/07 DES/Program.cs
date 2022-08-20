using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace _07_DES
{
    class TestDES {
        public static string EncryptText(string Data, byte[] key, byte[] IV) {
            return Convert.ToBase64String(EncryptTextMemory(Data, key, IV));
        }
        public static byte[] EncryptTextMemory(string Data, byte[] key, byte[] IV)
        {
            try
            {
                //Create a MemoryStream
                MemoryStream memoryStream = new MemoryStream();
                //Create a CryptoStream using the MemoryStream
                CryptoStream cryptoStream = new CryptoStream(
                    memoryStream,
                    new DESCryptoServiceProvider().CreateEncryptor(key, IV),
                    CryptoStreamMode.Write);
                //Conver the passed string to a byte array
                byte[] toEncrypt = Encoding.UTF8.GetBytes(Data);
                //Write the byte array to the crypto stream and flush it
                cryptoStream.Write(toEncrypt, 0, toEncrypt.Length);
                cryptoStream.FlushFinalBlock();
                //Get an array of bytes from the MemoryStream that holds the encrypted data
                byte[] ret = memoryStream.ToArray();
                //Close the stream
                cryptoStream.Close();
                memoryStream.Close();
                //Return the encrypted buffer
                return ret;
            }
            catch (CryptographicException e) {
                Console.WriteLine("A cryptographic error occured: {0}",e.Message);
                return null;
            }
        }
        public static string DecryptText(string sData, byte[] key, byte[] IV) {
            byte[] Data = Convert.FromBase64String(sData);
            return DecryptTextFromMemory(Data, key, IV);
        }
        public static string DecryptTextFromMemory(byte[] Data, byte[] key, byte[] IV)
        {
            try
            {
                //Create a MemoryStream using the passed array of encrypted data
                MemoryStream memoryStreamDecrypt = new MemoryStream(Data);

                //Create a CryptoStream using the MemoryStream and the passed key and initialization vector (IV)
                CryptoStream cryptoStreamDecrypt = new CryptoStream(
                                                        memoryStreamDecrypt,
                                                        new DESCryptoServiceProvider().CreateDecryptor(key, IV),
                                                        CryptoStreamMode.Read);

                //Create buffer to hold the decrypted data
                byte[] fromEncrypt = new byte[Data.Length];

                //Read the decrypted data out of the crypto stream and place it into the temporary buffer
                cryptoStreamDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it
                return Encoding.UTF8.GetString(fromEncrypt);
            }
            catch (CryptographicException e) {
                Console.WriteLine("A cryptographic error occured: {0}", e.Message);
                return null;
            }
        }
        static void Main(string[] args) {
            //try
            //{
            //    //Create a new DESCryptoServiceProvider object to generate a key and initialization vector (IV)
            //    DESCryptoServiceProvider DESalg = new DESCryptoServiceProvider();

            //    //input a string to encrypt
            //    Console.Write("input a message:");
            //    string sData = Console.ReadLine();

            //    //Encrypt the string to an in-memory buffer
            //    string encrypted = EncryptText(sData, DESalg.Key, DESalg.IV);
            //    Console.WriteLine("encryped message: " + encrypted);
            //    Console.ReadLine();

            //    //Display the decrypted string to the console
            //    Console.WriteLine("decrypted message: " + DecryptText(encrypted, DESalg.Key, DESalg.IV));
            //    Console.ReadLine();
            //}
            //catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}
            
            while (true) {
                Thread.Sleep(200);
                Console.WriteLine(Encoding.Default.GetString((new DESCryptoServiceProvider()).Key));
            }
        }
    }
}