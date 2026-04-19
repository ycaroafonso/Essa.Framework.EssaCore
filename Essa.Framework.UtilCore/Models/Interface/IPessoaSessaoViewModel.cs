using System.Collections.Generic;

namespace Essa.Framework.Util.Models.Interface;

public interface IPessoaSessaoViewModel : IEmpresaV2, IUsuarioV2
{
    string NomeEmpresa { get; set; }

    string NomePessoa { get; set; }
    int PessoaId { get; set; }

    string Login { get; set; }

    IPessoaPermissaoSessaoViewModel Permissao { get; set; }
}

public interface IPessoaPermissaoSessaoViewModel
{
    IList<int> PessoaIdsLocal { get; set; }
    IList<int> ContaIds { get; set; }
    IList<int> CentroCustoIds { get; set; }
    IList<int> ContaGerencialds { get; set; }
    IList<int> ClassificacaoIds { get; set; }
}
public interface IParametroPessoaViewModel
{
    IPessoaSessaoViewModel PessoaSessaoViewModel { get; set; }
}
