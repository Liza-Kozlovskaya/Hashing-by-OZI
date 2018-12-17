using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace RSAManager.Helpers
{
    public class RSAHelper
    {
        private readonly int _keySize;
        private readonly RSACryptoServiceProvider _provider;
        private readonly string _key;

        public RSAHelper(int keySize)
        {
            _provider = new RSACryptoServiceProvider(keySize);
            _key = _provider.ToXmlString(true);
            _keySize = keySize;
        }

        public string PublicKey()
        {
            return RSAKeyValue.ToPublicKey(_key).ToXml();
        }

        public string PrivateKey()
        {
            return RSAKeyValue.ToPrivateKey(_key).ToXml();
        }

        public byte[] Encrypt(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return _provider.Encrypt(bytes, false);
        }

        public string Decrypt(byte[] value)
        {
            byte[] decrypted = _provider.Decrypt(value, false);
            return Encoding.UTF8.GetString(decrypted);
        }

        public string EncryptString(string inputString, string publicKey)
        {
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider(_keySize))
            {
                rsaCryptoServiceProvider.FromXmlString(publicKey);
                int keySize = _keySize/8;
                byte[] bytes = Encoding.UTF32.GetBytes(inputString);
                int maxLength = keySize - 42;
                int dataLength = bytes.Length;
                int iterations = dataLength/maxLength;
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i <= iterations; i++)
                {
                    byte[] tempBytes =
                        new byte[(dataLength - maxLength*i > maxLength) ? maxLength : dataLength - maxLength*i];
                    Buffer.BlockCopy(bytes, maxLength*i, tempBytes, 0, tempBytes.Length);
                    byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                    Array.Reverse(encryptedBytes);
                    stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
                }
                return stringBuilder.ToString();
            }
        }

        public string DecryptString(string inputString, string privateKey)
        {
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider(_keySize))
            {
                rsaCryptoServiceProvider.FromXmlString(privateKey);
                int base64BlockSize = ((_keySize/8)%3 != 0) ? (((_keySize/8)/3)*4) + 4 : ((_keySize/8)/3)*4;
                int iterations = inputString.Length/base64BlockSize;
                ArrayList arrayList = new ArrayList();
                for (int i = 0; i < iterations; i++)
                {
                    byte[] encryptedBytes = Convert.FromBase64String(
                        inputString.Substring(base64BlockSize*i, base64BlockSize));
                    Array.Reverse(encryptedBytes);
                    arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(
                        encryptedBytes, true));
                }
                return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
            }
        }

    }
}
