namespace Essa.Framework.Util.Util.Criptografia
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;

    public class CriptografiaRijndaelManaged : IDisposable
    {
        private Aes _AES;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Chave externa: 16, 24, 32 bits</param>
        /// <param name="IV">Chave interno: 16 bits</param>
        public CriptografiaRijndaelManaged(byte[] key, byte[] IV)
        {
            _AES = Aes.Create("AesManaged");
            _AES.Key = key;
            _AES.IV = IV;
        }

        public CriptografiaRijndaelManaged(string key, string IV) : this(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(IV))
        {
        }


        public byte[] EncryptFile(byte[] bytesToBeEncrypted)
        {
            using (var cryptor = _AES.CreateEncryptor())
                return cryptor.TransformFinalBlock(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
        }


        public string EncryptStr(byte[] bytesToBeEncrypted)
        {
            using (var cryptor = _AES.CreateEncryptor())
            {
                var x = cryptor.TransformFinalBlock(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);

                string base64 = Convert.ToBase64String(x.ToArray());

                // Generate a string that won't get screwed up when passed as a query string.
                string urlEncoded = HttpUtility.UrlEncode(base64);
                return urlEncoded;
            }
        }

        public byte[] DecryptFile(byte[] bytesToBeDecrypted)
        {
            using (var cryptor = _AES.CreateDecryptor())
                return cryptor.TransformFinalBlock(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
        }


        public string DecryptStr(byte[] bytesToBeDecrypted)
        {
            using (var cryptor = _AES.CreateDecryptor())
            {
                var x = cryptor.TransformFinalBlock(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                string utf8 = Encoding.UTF8.GetString(x);
                return utf8;
            }
        }

        public void Dispose()
        {
            _AES.Dispose();
        }
    }
}