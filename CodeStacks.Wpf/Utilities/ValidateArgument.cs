using System;
using System.Text.RegularExpressions;

namespace xiaowen.codestacks.wpf.Utilities
{
    public class ValidateArgument
    {
        #region 正则匹配验证
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool MatchStartPartial(string key, string value)
        {
            Match match = Regex.Match(value, string.Format(@"^({0}).+", key));
            return match.Length > 0 ? true : false;
        }


        /// <summary>
        /// 验证非负整数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPositiveInteger(string key, string input)
        {
            return Regex.IsMatch(input, string.Format(@"^[1-9]\d*$"));
        }
        #endregion
        
        #region SenSing 验证时间范围
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool SenSing_ValidateRange(DateTime startDt, DateTime endDt, UInt16 range)
        {
            TimeSpan tsStart = new TimeSpan(startDt.Ticks);
            TimeSpan tsEnd = new TimeSpan(endDt.Ticks);
            if (tsEnd.TotalDays - tsStart.TotalDays > range)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool SenSing_ValidateRange(string startDt, string endDt, UInt16 range)
        {
            bool res = false;
            DateTime startDate, endDate;
            try
            {
                startDate = Convert.ToDateTime(startDt);
                endDate = Convert.ToDateTime(endDt);
                TimeSpan tsStart = new TimeSpan(startDate.Ticks);
                TimeSpan tsEnd = new TimeSpan(endDate.Ticks);

                if (tsEnd.TotalDays - tsStart.TotalDays < range)
                    res = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool SenSing_ValidateRange(long startDt, long endDt, UInt16 range)
        {
            bool res = false;
            DateTime startDate, endDate;
            try
            {
                startDate = Convert.ToDateTime(startDt);
                endDate = Convert.ToDateTime(endDt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return res;
        }
        #endregion
    }
}
