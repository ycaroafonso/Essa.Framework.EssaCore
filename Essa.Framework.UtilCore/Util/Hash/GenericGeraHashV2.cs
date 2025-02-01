using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Text;

namespace Essa.Framework.Util.Util.Hash
{
    [Serializable]
    public abstract class GenericGeraHashV2 : IGeraHash
    {
        private readonly string _chavePrivada;

        public GenericGeraHashV2() { }
        public GenericGeraHashV2(string chavePrivada)
        {
            _chavePrivada = chavePrivada;
        }


        public virtual string Hash { get; set; }


        public abstract string ToHashText();

        public virtual void GerarHash()
        {
            Hash = BCrypt.Net.BCrypt.HashPassword(ToHashText());
        }


        public bool IsHashValido(string hashParametro)
        {
            Hash = null;
            return BCrypt.Net.BCrypt.Verify(ToHashText(), hashParametro);
        }

        public void ValidaHash(string hashParametro)
        {
            if (!IsHashValido(hashParametro))
                throw new Exception("O hash informado não confere!");
        }


        public void ValidaHash()
        {
            string hashParametro = Hash;
            GerarHash();

            ValidaHash(hashParametro);
        }
    }
}
