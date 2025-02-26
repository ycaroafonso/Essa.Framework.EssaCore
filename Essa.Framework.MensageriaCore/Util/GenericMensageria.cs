using System;
using System.Threading.Tasks;

namespace Essa.Framework.Mensageria.Util;
internal abstract class GenericMensageria : IDisposable
{
    protected CadastrarMensageria _cadastrarMensageria;


    public GenericMensageria(ConexaoMensageria conexao, string fila)
    {
        _cadastrarMensageria = new CadastrarMensageria(conexao);
        _cadastrarMensageria.CriarFila(fila, arguments: null);
    }

    public async Task Publicar<T>(T envio)
    {
        await _cadastrarMensageria.Publicar(envio);
    }





    public async Task Receber<T>(Func<ulong, T, Task> received)
    {
        await _cadastrarMensageria.Receber(received);
        Console.ReadLine();
    }
    public async Task ConfirmarRecebimento(ulong tag)
    {
        await _cadastrarMensageria.ConfirmarRecebimento(tag);
    }

    public void Dispose()
    {
        _cadastrarMensageria.Dispose();
    }
}


public abstract class GenericMensageria<T> : IDisposable
    where T : class
{
    private CadastrarMensageria _cadastrarMensageria;

    public GenericMensageria()
    {

    }

    public GenericMensageria(IConexaoMensageria conexao, string fila)
    {
        _cadastrarMensageria = new CadastrarMensageria(conexao);
        _cadastrarMensageria.CriarFila(fila, arguments: null);
    }


    public virtual async void Publicar(T envio)
    {
        await _cadastrarMensageria.Publicar(envio);
    }



    public async Task Receber(Func<ulong, T, Task> received)
    {
        await _cadastrarMensageria.Receber(received);
    }


    public async Task ConfirmarRecebimento(ulong tag)
    {
        await _cadastrarMensageria.ConfirmarRecebimento(tag);
    }

    public void Dispose()
    {
        _cadastrarMensageria.Dispose();
    }
}