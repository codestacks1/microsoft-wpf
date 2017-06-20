using System;
using Thrift.Transport;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    [CLSCompliant(false)]
    /// <summary>
    /// Thrift 请求结果类
    /// </summary>
    public class ThriftResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="transport">socket</param>
        /// <param name="thriftOpt">thriftservice interface</param>
        /// <returns></returns>
        public static TResult GetResult<TResult>(TTransport transport, Func<TResult> thriftOpt)
            where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                if (thriftOpt != null) t = thriftOpt.Invoke();
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
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
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1>(TTransport transport, Func<T1, TResult> thriftOpt, params object[] param)
            where TResult : new()
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
            finally
            {
                transport.Close();
            }
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="transport"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="methodName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1, T2>(TTransport transport, Func<T1, T2, TResult> thriftOpt, params object[] param)
            where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                     (T1)param[0],
                     (T2)param[1]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
            }
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="transport"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="methodName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1, T2, T3>(TTransport transport, Func<T1, T2, T3, TResult> thriftOpt, params object[] param)
            where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
            }
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="transport"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="methodName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1, T2, T3, T4>(TTransport transport, Func<T1, T2, T3, T4, TResult> thriftOpt, params object[] param)
            where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
            }
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="transport"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="methodName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1, T2, T3, T4, T5>(TTransport transport, Func<T1, T2, T3, T4, T5, TResult> thriftOpt, params object[] param)
           where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                     (T1)param[0],
                     (T2)param[1],
                     (T3)param[2],
                     (T4)param[3],
                     (T5)param[4]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
            }
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="transport"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="methodName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1, T2, T3, T4, T5, T6>(TTransport transport, Func<T1, T2, T3, T4, T5, T6, TResult> thriftOpt, params object[] param)
           where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
            }
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="transport"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="methodName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1, T2, T3, T4, T5, T6, T7>(TTransport transport, Func<T1, T2, T3, T4, T5, T6, T7, TResult> thriftOpt, params object[] param)
           where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5],
                    (T7)param[6]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
            }
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="transport"></param>
        /// <param name="methodName"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(TTransport transport, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> thriftOpt, params object[] param)
          where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5],
                    (T7)param[6],
                    (T8)param[7]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
            }
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <param name="transport"></param>
        /// <param name="methodName"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(TTransport transport, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> thriftOpt, params object[] param)
          where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5],
                    (T7)param[6],
                    (T8)param[7],
                    (T9)param[8]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
            }
            return t;
        }

        public static TResult GetResult<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(TTransport transport, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> thriftOpt, params object[] param)
          where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5],
                    (T7)param[6],
                    (T8)param[7],
                    (T9)param[8],
                    (T10)param[9]);
            }
            catch (Exception ex)
            {
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
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <param name="transport"></param>
        /// <param name="methodName"></param>
        /// <param name="thriftOpt"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult GetResult<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(TTransport transport, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> thriftOpt, params object[] param)
          where TResult : new()
        {
            TResult t = new TResult();

            try
            {
                if (!transport.IsOpen) transport.Open();
                t = thriftOpt.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5],
                    (T7)param[6],
                    (T8)param[7],
                    (T9)param[8],
                    (T10)param[9],
                    (T11)param[10]);
            }
            catch (Exception ex)
            {
                transport.Close();
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                transport.Close();
            }
            return t;
        }
    }
}
