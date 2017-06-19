using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;
using xiaowen.codestacks.data.Utilities;

namespace Xiaowen.CodeStacks.Thrift.Utilities
{
    /// <summary>
    /// 通用版Socket连接框架
    /// </summary>
    public class ThriftSocketUtilities
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="timeout"></param>
        /// <param name="bServerClient"></param>
        /// <returns></returns>
        //public static TTransport Init(string host, int port, int timeout, ref BusinessServer.Client bServerClient)
        //{
        //    TTransport transport = null;
        //    try
        //    {
        //        if (timeout > 0)
        //            transport = new TSocket(host, port, timeout);
        //        else
        //            transport = new TSocket(host, port, GlobalCache.SocketTimeout * 1000);
        //        TProtocol protocol = new TBinaryProtocol(transport);
        //        bServerClient = new BusinessServer.Client(protocol);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //    return transport;
        //}
        

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="transport"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="methodName"></param>
        /// <param name="isAppearErr"></param>
        /// <returns></returns>
        public static TResult GetResult<ErrObj, TResult>(TTransport transport, Func<TResult> thriftOpt, string methodName, bool isAppearErr)
           where TResult : new()
           where ErrObj : class
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                if (thriftOpt != null) t = thriftOpt.Invoke();
            }
            catch (Exception ex)
            {
                //测试环境下给予提示
                //methodName heart
                transport.Close();
                throw new Exception(ex.Message, ex);
            }

            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="transport"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="methodName"></param>
        /// <param name="isAppearErr"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<ErrObj, TResult, T1>(TTransport transport, Func<T1, TResult> thriftOpt, string methodName, bool isAppearErr, params object[] param)
           where TResult : new()
           where ErrObj : class
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke((T1)param[0]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }

            return t;
        }

    }
}
