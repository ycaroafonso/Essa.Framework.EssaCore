namespace Essa.Framework.Util.Util
{
    using Essa.Framework.Util.Extensions;
    using Essa.Framework.Util.Models.Autenticacao;
    using System;


    public class Autenticacao
    {
        Uri _requestUrl;
        string _ipCliente;
        public bool IsLocal { get { return _requestUrl.Host == "192.168.0.110" || _ipCliente == "179.124.9.149" || _ipCliente == "::1"; } }



        public IAutenticacaoViewModel AutenticacaoViewModel { get; private set; }



        public Autenticacao(IAutenticacaoViewModel autenticacaoViewModel, string ipCliente, Uri requestUrl)
        {
            _requestUrl = requestUrl;

            _ipCliente = ipCliente;
            _ipCliente = IsLocal ? "::1" : _ipCliente;

            AutenticacaoViewModel = autenticacaoViewModel;
        }

        public Autenticacao(IAutenticacaoViewModel autenticacaoViewModel, string parametro, string ipCliente, Uri requestUrl)
            : this(autenticacaoViewModel, ipCliente, requestUrl)
        {
            ConverterParametroParaObjeto(parametro);

        }

        public void IsValidaData()
        {
            if ((DateTime.Now - AutenticacaoViewModel.Data).TotalMinutes > 3)
                throw new Exception("O hash informado expirou");
        }

        public void IsValidaUsuario(string senha, int portalmoduloid = 0)
        {
            string hashUrl = AutenticacaoViewModel.Hash;
            MontaAutenticacaoViewModel(senha);
            string hashNovo = AutenticacaoViewModel.Hash;

            if (hashUrl != hashNovo)
                throw new Exception("O hash informado não confere!");
        }


        public string RetornaParametroAutenticacao()
        {
            return EncryptParam.Encrypt(
                    string.Concat(
                        "hash=", AutenticacaoViewModel.Hash,
                        "&login=", AutenticacaoViewModel.Login,
                        "&portalmoduloid=", AutenticacaoViewModel.PortalModuloId,
                        "&data=", AutenticacaoViewModel.Data
                        )
                    );
        }




        public void MontaAutenticacaoViewModel(string senha)
        {
            AutenticacaoViewModel.Senha = senha;
            AutenticacaoViewModel.IsVerificarIp = true;
            AutenticacaoViewModel.Ip = _ipCliente;
            AutenticacaoViewModel.Hash = null;

            AutenticacaoViewModel.Hash = new CriptografiaMd5().Encrypt(AutenticacaoViewModel.ToString());
        }
        public void MontaAutenticacaoViewModel(string login, string senha, int portalmoduloid, DateTime data)
        {
            AutenticacaoViewModel.Login = login.ToUpper();
            AutenticacaoViewModel.Senha = senha;
            AutenticacaoViewModel.IsVerificarIp = true;
            AutenticacaoViewModel.Ip = _ipCliente;
            AutenticacaoViewModel.PortalModuloId = portalmoduloid;
            AutenticacaoViewModel.Data = data;
            AutenticacaoViewModel.Hash = null;

            AutenticacaoViewModel.Hash = new CriptografiaMd5().Encrypt(AutenticacaoViewModel.ToString());
        }

        private void ConverterParametroParaObjeto(string parametro)
        {
            parametro = EncryptParam.Decrypt(parametro);

            foreach (string item in parametro.Split('&'))
            {
                string[] par = item.Split('=');
                switch (par[0])
                {
                    case "hash":
                        AutenticacaoViewModel.Hash = par[1];
                        break;
                    case "login":
                        AutenticacaoViewModel.Login = par[1];
                        break;
                    case "portalmoduloid":
                        AutenticacaoViewModel.PortalModuloId = par[1].ToInt32();
                        break;
                    case "data":
                        AutenticacaoViewModel.Data = Convert.ToDateTime(par[1]);
                        break;
                }
            }
        }
    }
}
