namespace Essa.Framework.MensageriaCore.Util
{
    using Essa.Framework.Mensageria;
    using System;


    public abstract class GenericMensageria : IDisposable
    {
        protected CadastrarMensageria _cadastrarMensageria;


        public GenericMensageria(ConexaoMensageria conexao, string fila)
        {
            _cadastrarMensageria = new CadastrarMensageria(conexao);
            _cadastrarMensageria.CriarFila(fila, arguments: null);
        }

        public void Publicar<T>(T envio)
        {
            _cadastrarMensageria.Publicar(envio);
        }





        public void Receber<T>(Action<ulong, T> received)
        {
            _cadastrarMensageria.Receber(received);
            Console.ReadLine();
        }
        public void ConfirmarRecebimento(ulong tag)
        {
            _cadastrarMensageria.ConfirmarRecebimento(tag);
        }

        public void Dispose()
        {
            _cadastrarMensageria.Dispose();
        }
    }


    public abstract class GenericMensageria<T> : IDisposable
        where T : class
    {
        protected CadastrarMensageria _cadastrarMensageria;

        public GenericMensageria()
        {

        }

        public GenericMensageria(ConexaoMensageria conexao, string fila)
        {
            _cadastrarMensageria = new CadastrarMensageria(conexao);
            _cadastrarMensageria.CriarFila(fila, arguments: null);
        }


        public virtual void Publicar(T envio)
        {
            _cadastrarMensageria.Publicar(envio);
        }




        [Obsolete]
        public void Receber(Action<ulong, T> received)
        {
            _cadastrarMensageria.Receber(received);
            Console.ReadLine();
        }

        public void Receber2(Action<ulong, T> received)
        {
            _cadastrarMensageria.Receber(received);
        }


        public void ConfirmarRecebimento(ulong tag)
        {
            _cadastrarMensageria.ConfirmarRecebimento(tag);
        }

        public void Dispose()
        {
            _cadastrarMensageria.Dispose();
        }
    }
}