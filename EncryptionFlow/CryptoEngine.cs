using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionFlow
{
    using System;
    using System.IO;
    using System.Security.Cryptography;

    namespace FolderLockerApp
    {
        public static class CryptoEngine
        {
            private static readonly byte[] saltBytes = new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };

            public static void FileEncrypt(string inputFile, string password)
            {
                string outputFile = inputFile + ".locked";

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    using (var keyDerivation = new Rfc2898DeriveBytes(password, saltBytes, 10000))
                    {
                        using (Aes aes = Aes.Create())
                        {
                            aes.KeySize = 256;
                            aes.Key = keyDerivation.GetBytes(32);
                            aes.IV = keyDerivation.GetBytes(16);

                            using (CryptoStream cs = new CryptoStream(fsOutput, aes.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                fsInput.CopyTo(cs);
                            }
                        }
                    }
                }
                File.Delete(inputFile); 
            }

            public static void FileDecrypt(string inputFile, string password)
            {
                string outputFile = inputFile.Substring(0, inputFile.Length - 7);

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    using (var keyDerivation = new Rfc2898DeriveBytes(password, saltBytes, 10000))
                    {
                        using (Aes aes = Aes.Create())
                        {
                            aes.KeySize = 256;
                            aes.Key = keyDerivation.GetBytes(32);
                            aes.IV = keyDerivation.GetBytes(16);

                            using (CryptoStream cs = new CryptoStream(fsOutput, aes.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                fsInput.CopyTo(cs);
                            }
                        }
                    }
                }
                File.Delete(inputFile); 
            }
        }
    }
}
