using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Requests
{
    public class ShowSearchRequestVM
    {
        public short? ShowTypeId { get; set; }
        public string SearchString { get; set; }

        public int Take { get; set; } = 10;
        public int Skip { get; set; }
    }
}
