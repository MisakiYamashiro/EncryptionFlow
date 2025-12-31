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
            // Sabit Tuz (Salt) değeri. Güvenlik için değiştirilebilir.
            private static readonly byte[] saltBytes = new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };

            public static void FileEncrypt(string inputFile, string password)
            {
                // Şifrelenmiş dosya ".locked" uzantısını alacak
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
                File.Delete(inputFile); // Orijinal dosyayı sil
            }

            public static void FileDecrypt(string inputFile, string password)
            {
                // ".locked" uzantısını kaldırarak orijinal isme dön
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
                File.Delete(inputFile); // Şifreli dosyayı sil
            }
        }
    }
}
