using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Test.Models
{
    public class ListVehicleDates
    {
        public DateTime dates { get; set; }

        public ListVehicleDates(DateTime dates)
        {
            this.dates = dates;
        }
    }
}