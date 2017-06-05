using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace xiaowen.codestacks.data.Utilities
{
    public class NetWork
    {
        public static string GetHostIpAddress()
        {
            string host = Dns.GetHostName();
            IPHostEntry locahost = Dns.GetHostEntry(host);
            IPAddress ip = locahost.AddressList[0];
            return ip.ToString();
        }
    }
}
