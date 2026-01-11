using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.RapidAPIDTOs
{
    public class ExchangeAPIDTO
    {
        public class Rootobject
        {
            public string status { get; set; }
            public string request_id { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public string from_symbol { get; set; }
            public string to_symbol { get; set; }
            public string type { get; set; }
            public decimal exchange_rate { get; set; }
            public decimal previous_close { get; set; }
            public string last_update_utc { get; set; }
        }
    }
}

