using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StringConnection
    {
        public static string ConnectionApp
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionStringApp"].ToString();
            }
        }
    }
}
