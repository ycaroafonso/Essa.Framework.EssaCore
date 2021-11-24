using EssaGestaoCore.DTO.Calendario;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essa.Framework.GoogleApi.Calendario.Calendario
{
    public class ObterEventosService
    {
        private GetCalendarioService getCalendarioService;
        private string googlecalendarioid;
        private string diretorio;

        public ObterEventosService(GetCalendarioService getCalendarioService, string googlecalendarioid, string diretorio)
        {
            this.getCalendarioService = getCalendarioService;
            this.googlecalendarioid = googlecalendarioid;
            this.diretorio = diretorio;
        }

        public List<Event> ObterEventos()
        {
            throw new NotImplementedException();
        }
    }
}
