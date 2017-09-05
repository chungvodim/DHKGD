using System.Collections.Generic;

namespace Tearc.Utils.Repository
{
    public class PagingResult<T> 
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int ItemCount { get; set; }
        public List<T> Items { get; set; }
    }
}
