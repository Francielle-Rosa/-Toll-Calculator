using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Test.Models
{
    public class Historic
    {
        public int vehicleId { get; set; }
        public string vehicleType { get; set; }
        public DateTime dates { get; set; }

        public Historic (int vehicleId, string vehicleType, DateTime dates)
        {
            this.vehicleId = vehicleId;
            this.vehicleType = vehicleType;
            this.dates = dates;          
        }

    }
}