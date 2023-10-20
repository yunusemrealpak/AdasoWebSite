using System;

namespace Entities.Dtos.Filter
{
    public class FilterFullCalendar
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool hedefTekrarFaaliyetMi { get; set; } = true;
    }
}
