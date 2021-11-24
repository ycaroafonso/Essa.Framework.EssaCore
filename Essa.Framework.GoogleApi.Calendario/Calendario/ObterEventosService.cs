using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;

namespace Essa.Framework.GoogleApi.Calendario.Calendario
{
    public class ObterEventosService
    {
        private GetCalendarioService _getCalendarioService;
        private string _googlecalendarioid;

        public ObterEventosService(GetCalendarioService getCalendarioService, string googlecalendarioid)
        {
            this._getCalendarioService = getCalendarioService;
            this._googlecalendarioid = googlecalendarioid;
        }


        public IList<Event> ObterEventos()
        {
            // Define parameters of request.
            EventsResource.ListRequest request = _getCalendarioService.Service.Events.List(_googlecalendarioid);
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();

            return events.Items;
        }
    }
}
