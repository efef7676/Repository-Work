using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Core
{
    public static class ConfigurationValues
    {
        public static int TimeOutWaitSeconds => int.Parse(ConfigurationManager.AppSettings["TIME_OUT_WAIT_SECONDS"]);
    }
}
