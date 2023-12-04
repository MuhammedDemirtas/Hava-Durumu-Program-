using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hava_Durumu_Projesi
{
    class Veriler
    {
        public string Temperature { get; set; }
        public string Description { get; set; }
        public string Wind { get; set; }
        public Forecast[] Forecast { get; set; }
    }
}
