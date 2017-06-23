using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Xiaowen.CodeStacks.Data.Utilities
{
    /// <summary>
    /// 网络连接相关接口
    /// </summary>
    public class CodeStacksNetWork
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressFamily"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetHostIpAddress(AddressFamily addressFamily, params Int16[] index)
        {
            IPAddress ip = null;
            string host = Dns.GetHostName();
            IPHostEntry locahost = Dns.GetHostEntry(host);
            var ipAddress = locahost.AddressList.Where(i => i.AddressFamily.Equals(addressFamily));

            if (index.Length > 1)
            {
                return "最大长度为-'1'";
            }
            else
            {
                try
                {
                    ip = ipAddress.Cast<IPAddress>().ToList()[index[0]];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            return ip.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressFamily"></param>
        /// <returns></returns>
        public static IEnumerable<IPAddress> GetHostIpAddress(AddressFamily addressFamily)
        {
            string host = Dns.GetHostName();
            IPHostEntry localhost = Dns.GetHostEntry(host);
            return localhost.AddressList.Where(i => i.AddressFamily.Equals(addressFamily));
        }



    }
}
