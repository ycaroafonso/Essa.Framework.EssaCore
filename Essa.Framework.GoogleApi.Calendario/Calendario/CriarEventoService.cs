using EssaGestaoCore.DTO.Calendario;
using System;

namespace Essa.Framework.GoogleApi.Calendario.Calendario
{
    public class CriarEventoService
    {
        private GetCalendarioService getCalendarioService;

        public CriarEventoService(GetCalendarioService getCalendarioService)
        {
            this.getCalendarioService = getCalendarioService;
        }

        public void Cadastrar(CalendarioEventoDTO evento)
        {

        }

        public void Excluir(CalendarioEventoDTO evento)
        {

        }

        public void Atualizar(CalendarioEventoDTO evento)
        {

        }
    }
}
