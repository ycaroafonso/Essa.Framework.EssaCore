using System;

namespace Essa.Framework.Util.Util.Hash
{
    [Serializable]
    [Obsolete("Utilizar GenericGeraHashV2")]
    public abstract class GenericGeraHash : IGeraHash
    {
        private readonly string _chavePrivada;

        public GenericGeraHash() { }
        public GenericGeraHash(string chavePrivada)
        {
            _chavePrivada = chavePrivada;
        }


        public virtual string Hash { get; set; }


        public abstract string ToHashText();

        public virtual void GerarHash()
        {
            Hash = null;
            Hash = new CriptografiaMd5().Encrypt(_chavePrivada + ToHashText());
        }


        public bool IsHashValido(string hashParametro)
        {
            return Hash == hashParametro;
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
