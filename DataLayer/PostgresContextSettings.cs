using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PostgresContextSettings
    {
        public PostgresContextSettings(string connectionstr)
        {
            this.PostgresConnectionString = connectionstr;
        }

        public string PostgresConnectionString {get;}
    }
}
