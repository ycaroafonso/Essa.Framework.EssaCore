namespace Essa.Framework.Util.Repository
{
    public interface IGenericSalvarRepository
    {
        int Salvar();
        Task<int> SalvarAsync();
    }
}
