namespace Essa.Framework.Util.Models.Interface
{
    public interface IEmpresa
    {
        int empresaid { get; set; }
    }
    public interface IEmpresaV2
    {
        int EmpresaId { get; set; }
    }
    public interface IEmpresaV2AllowNull
    {
        int? EmpresaId { get; set; }
    }
}
