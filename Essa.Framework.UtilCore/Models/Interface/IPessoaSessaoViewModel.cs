using System.Collections.Generic;

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
        IPessoaPermissaoSessaoViewModel Permissao { get; set; }
    }

    public interface IPessoaPermissaoSessaoViewModel
    {
        IList<int> PessoaIdsLocal { get; set; }
        IList<int> ContaIds { get; set; }

    }
    public interface IParametroPessoaViewModel
    {
        IPessoaSessaoViewModel PessoaSessaoViewModel { get; set; }
    }
}
