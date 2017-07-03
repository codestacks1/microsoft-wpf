using System;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    public class CodeStacksErrorHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="errMsg">错误消息</param>
        /// <param name="exeMethod">执行的方法名</param>
        /// <param name="method">方法名</param>
        /// <param name="param">方法是用的参数,最后一位是错误方法路径param[param.Length-1]</param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult>(string errMsg, string exeMethod, Func<TResult> method, params object[] param)
            where ErrObj : class
            where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke();
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1>(string errMsg, string exeMethod, Func<T1, TResult> method, params object[] param)
    where ErrObj : class
    where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2>(string errMsg, string exeMethod, Func<T1, T2, TResult> method, params object[] param)
    where ErrObj : class
    where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0],
                    (T2)param[1]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ErrObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3>(string errMsg, string exeMethod, Func<T1, T2, T3, TResult> method, params object[] param)
    where ErrObj : class
    where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
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
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3, T4>(string errMsg, string exeMethod, Func<T1, T2, T3, T4, TResult> method, params object[] param)
    where ErrObj : class
    where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
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
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3, T4, T5>(string errMsg, string exeMethod, Func<T1, T2, T3, T4, T5, TResult> method, params object[] param)
where ErrObj : class
where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
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
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3, T4, T5, T6>(string errMsg, string exeMethod, Func<T1, T2, T3, T4, T5, T6, TResult> method, params object[] param)
where ErrObj : class
where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
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
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3, T4, T5, T6, T7>(string errMsg, string exeMethod, Func<T1, T2, T3, T4, T5, T6, T7, TResult> method, params object[] param)
where ErrObj : class
where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5],
                    (T7)param[6]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
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
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3, T4, T5, T6, T7, T8>(string errMsg, string exeMethod, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> method, params object[] param)
where ErrObj : class
where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5],
                    (T7)param[6],
                    (T8)param[7]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
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
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string errMsg, string exeMethod, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> method, params object[] param)
where ErrObj : class
where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5],
                    (T7)param[6],
                    (T8)param[7],
                    (T9)param[8]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
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
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string errMsg, string exeMethod, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> method, params object[] param)
where ErrObj : class
where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
                    (T1)param[0],
                    (T2)param[1],
                    (T3)param[2],
                    (T4)param[3],
                    (T5)param[4],
                    (T6)param[5],
                    (T7)param[6],
                    (T8)param[7],
                    (T9)param[8],
                    (T10)param[9]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
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
        /// <param name="errMsg"></param>
        /// <param name="exeMethod"></param>
        /// <param name="method"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string errMsg, string exeMethod, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> method, params object[] param)
where ErrObj : class
where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
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
                    (T11)param[10]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
        }

        public static TResult TryCatch<ErrObj, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string errMsg, string exeMethod, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> method, params object[] param)
where ErrObj : class
where TResult : class, new()
        {
            TResult result = new TResult();
            try
            {
                result = method.Invoke(
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
                    (T11)param[10],
                    (T12)param[12]
                    );
            }
            catch (Exception ex)
            {
                CodeStacksLogger<ErrObj>.Log.Error(exeMethod + "\n\t", ex);

                if (true)
                {

                }
            }
            return result;
        }
    }
}
