namespace Essa.Framework.UtilCore.Models.Helpers.FullCalendar
{
    using System;


    public class FullCalendarOptions
    {
        public enum timezonesEnum
        {
            @false,
            local,
            UTC
        }

        public string timezones { get; set; }

        public FullCalendarOptions SetTimeZones(timezonesEnum timezones)
        {
            this.timezones = timezones.ToString();
            return this;
        }
    }

    public class FullCalendarEventsSource
    {
        public FullCalendarEvents[] events { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
    }


    public class FullCalendarEvents<T> : FullCalendarEvents
    {
        public T parameters { get; set; }
    }


    public class FullCalendarEvents
    {
        public string id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime? end { get; set; }
        public bool allDay { get; set; }


        public string color { get; set; }
        public string eventTextColor { get; set; }

        public bool editable { get; set; }

        /// <summary>
        /// Bloqueia o drag & drop para não ter outro evento junto;
        /// TODO: não funcionou
        /// </summary>
        public bool slotEventOverlap { get; set; }
    }
}
