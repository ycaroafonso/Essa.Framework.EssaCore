namespace Essa.Framework.Util.Models.Interface
{
    public interface IPessoaSessaoViewModel
    {
        int EmpresaId { get; set; }
        string NomeEmpresa { get; set; }

        string NomePessoa { get; set; }
        int PessoaId { get; set; }

        string Login { get; set; }

        int UsuarioId { get; set; }
    }
}
