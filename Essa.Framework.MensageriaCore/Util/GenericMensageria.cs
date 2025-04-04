using System;
using System.Threading.Tasks;

namespace Essa.Framework.Mensageria.Util;

internal interface IGenericMensageria : IDisposable
{
    Task ConfirmarRecebimento(ulong tag);
    Task Publicar<T>(T envio);
    Task Receber<T>(Func<ulong, T, Task> received);
}

internal abstract class GenericMensageria(IConexaoMensageria conexao, string fila) : IGenericMensageria
{
    protected ICadastrarMensageria _cadastrarMensageria;

    public async Task Publicar<T>(T envio)
    {
        _cadastrarMensageria = await conexao.NovaFila();
        await _cadastrarMensageria.CriarFila(fila, arguments: null);

        await _cadastrarMensageria.Publicar(envio);
    }


    public async Task Receber<T>(Func<ulong, T, Task> received)
    {
        _cadastrarMensageria = await conexao.NovaFila();
        await _cadastrarMensageria.CriarFila(fila, arguments: null);

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

public interface IGenericMensageria<T> : IDisposable where T : class
{
    Task ConfirmarRecebimento(ulong tag);
    Task Publicar(T envio);
    Task Receber(Func<ulong, T, Task> received);
}

public abstract class GenericMensageria<T>(IConexaoMensageria conexao, string fila) : IDisposable, IGenericMensageria<T> where T : class
{

    private ICadastrarMensageria _cadastrarMensageria;

    public virtual async Task Publicar(T envio)
    {
        _cadastrarMensageria = await conexao.NovaFila();
        await _cadastrarMensageria.CriarFila(fila, arguments: null);


        await _cadastrarMensageria.Publicar(envio);
    }



    public async Task Receber(Func<ulong, T, Task> received)
    {
        _cadastrarMensageria = await conexao.NovaFila();
        await _cadastrarMensageria.CriarFila(fila, arguments: null);

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