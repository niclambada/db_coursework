using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCW
{
    public class DBUtils
    {
        public static OracleConnection GetDBConnection()
        {
            string host = "192.168.100.10";
            int port = 1522;
            string sid = "orcl";
            string user = "System";
            string password = "Password123";

            return DBOracleUtils.GetDBConnection(host, port, sid, user, password);
        }
    }
}
