using Budget.Infrastructure.Common.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Common.Utils
{
    public class SecurityTools
    {
        private readonly KeyValuesConfiguration _keyValuesConfiguration;

        //public static void ConfigurationEncrypt(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public SecurityTools(IOptions<KeyValuesConfiguration> keyValuesConfiguration)
        {
            _keyValuesConfiguration = keyValuesConfiguration.Value;
        }

        public string EncryptPlainText(string plainText)
        {
            //var key = _configuration.GetConnectionString("KeyHash");
            var key = _keyValuesConfiguration.KeyHash;
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public string DecryptString(string cipherText)
        {
            //var key = _configuration.GetConnectionString("KeyHash");
            var key = _keyValuesConfiguration.KeyHash;
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
       
    }
}
