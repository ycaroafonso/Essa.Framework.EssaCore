namespace Essa.Framework.UtilCore.Util.Criptografia
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;


    public class CriptografiaRijndaelManaged : IDisposable
    {
        private RijndaelManaged _AES;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Chave externa: 16, 24, 32 bits</param>
        /// <param name="IV">Chave interno: 16 bits</param>
        public CriptografiaRijndaelManaged(byte[] key, byte[] IV)
        {
            _AES = new RijndaelManaged();
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

        public byte[] DecryptFile(byte[] bytesToBeDecrypted)
        {
            using (var cryptor = _AES.CreateDecryptor())
                return cryptor.TransformFinalBlock(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
        }

        public void Dispose()
        {
            _AES.Dispose();
        }
    }
}