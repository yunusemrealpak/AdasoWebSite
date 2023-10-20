using System.Collections.Generic;

namespace Entities.Dtos.Filter
{
    public class FilterDTO
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int PageSize { get; set; }
        public List<SortCriteria> Sort { get; set; }
        public List<FilterCriteria> Filter { get; set; }

    }

    public class SortCriteria
    {
        public string _field { get; set; }
        public string _dir { get; set; }
    }

    public class FilterCriteria
    {

        public string _field { get; set; }
        public string _operator { get; set; }
        public string _value { get; set; }
        public string _ignoreCase { get; set; }
        public string _logic { get; set; }

    }
}

