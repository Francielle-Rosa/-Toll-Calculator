using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Test.Models
{
    public class ListVehicle
    {
        public DateTime dates { get; set; }

        public ListVehicle(DateTime dates)
        {
            this.dates = dates;
        }
    }
}