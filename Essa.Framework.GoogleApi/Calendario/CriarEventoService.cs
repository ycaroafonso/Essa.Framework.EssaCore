using EssaGestaoCore.DTO.Calendario;
using Google.Apis.Calendar.v3.Data;
using System;

namespace Essa.Framework.GoogleApi.Calendario.Calendario
{
    public class CriarEventoService
    {
        private GetCalendarioService _getCalendarioService;

        public CriarEventoService(GetCalendarioService getCalendarioService)
        {
            this._getCalendarioService = getCalendarioService;
        }

        public void Cadastrar(CalendarioEventoDTO evento)
        {
            var newEvent = new Event()
            {
                Summary = evento.titulo,
                Start = new EventDateTime() { DateTime = evento.datainicio },
                End = new EventDateTime() { DateTime = evento.datafim },
            };

            newEvent = _getCalendarioService.Service.Events.Insert(newEvent, evento.googlecalendarioid).Execute();

            evento.googleeventoid = newEvent.Id;
        }

        public void Excluir(CalendarioEventoDTO calendarioEventoDTO)
        {
            var newEvent = new Event()
            {
                Summary = calendarioEventoDTO.titulo,
                Start = new EventDateTime() { DateTime = calendarioEventoDTO.datainicio },
                End = new EventDateTime() { DateTime = calendarioEventoDTO.datafim },
                Id = calendarioEventoDTO.googleeventoid
            };

            newEvent = _getCalendarioService.Service.Events.Update(newEvent, calendarioEventoDTO.googlecalendarioid, calendarioEventoDTO.googleeventoid).Execute();
        }

        public void Atualizar(CalendarioEventoDTO calendarioEventoDTO)
        {
            var resultado = _getCalendarioService.Service.Events.Delete(calendarioEventoDTO.googlecalendarioid, calendarioEventoDTO.googleeventoid).Execute();
        }
    }
}
