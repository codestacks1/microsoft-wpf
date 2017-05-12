using System;

namespace xiaowen.codestacks.data.DataHandler
{
    public class DateTimeData
    {
        internal DateTimeData()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Func<DateTime, long> ConvertToLongDelegate
        {
            get { return this.ConvertToLong; }
        }

        public Func<long, string> ConvertToStringDelegate
        {
            get { return this.ConvertToString; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isStart"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public Func<bool, string, int, int, long> ConvertToLongDelegate1
        {
            get { return this.ConvertToLong; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalSeconds"></param>
        /// <returns></returns>
        public Func<long, DateTime> ConvertToDateTimeDelegate
        {
            get { return this.ConvertToDateTime; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="now"></param>
        /// <param name="basic"></param>
        /// <returns></returns>
        public Func<DateTime, DateTime, long> ConvertToLongBySubstractDelegate
        {
            get { return this.ConvertToLongBySubstract; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private long ConvertToLong(DateTime dt)
        {
            DateTime datetime = new DateTime(1970, 1, 1);
            TimeSpan tsDatetime = new TimeSpan(datetime.Ticks);
            return Convert.ToInt64(tsDatetime.TotalSeconds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isStart"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        private long ConvertToLong(bool isStart, string date, int time, int minute)
        {
            long result = -1;
            if (isStart)
            {
                if (!string.IsNullOrEmpty(date))
                {
                    DateTime dt1 = Convert.ToDateTime(date);
                    TimeSpan dt1Span = new TimeSpan(dt1.Ticks);

                    DateTime dt2 = new DateTime(1970, 1, 1);
                    TimeSpan dt2Span = new TimeSpan(dt2.Ticks);

                    result = Convert.ToInt64(dt1Span.TotalSeconds - dt2Span.TotalSeconds);
                    if (time != -1)
                    {
                        result = result + int.Parse(time.ToString()) * 60 * 60 + minute * 60;
                    }
                }
                return result;
            }
            else
            {
                ////结束时间
                //long longdtPkCompRecordEndTime = -1;
                if (!string.IsNullOrEmpty(date))
                {
                    DateTime dt1 = Convert.ToDateTime(date);
                    TimeSpan dt1Span = new TimeSpan(dt1.Ticks);

                    DateTime dt2 = new DateTime(1970, 1, 1);
                    TimeSpan dt2Span = new TimeSpan(dt2.Ticks);

                    result = Convert.ToInt64(dt1Span.TotalSeconds - dt2Span.TotalSeconds);
                    if (time != -1)
                    {
                        result = result + int.Parse(time.ToString()) * 60 * 60 + minute * 60;
                    }
                }
                else
                {
                    string strCompRecordEndTime = System.DateTime.Now.ToString();
                    DateTime dt1 = Convert.ToDateTime(strCompRecordEndTime);
                    TimeSpan dt1Span = new TimeSpan(dt1.Ticks);

                    DateTime dt2 = new DateTime(1970, 1, 1);
                    TimeSpan dt2Span = new TimeSpan(dt2.Ticks);
                    result = Convert.ToInt64(dt1Span.TotalSeconds - dt2Span.TotalSeconds);
                }
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalSeconds"></param>
        /// <returns></returns>
        private DateTime ConvertToDateTime(long totalSeconds)
        {
            return new DateTime(1970, 1, 1).AddSeconds(totalSeconds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="now"></param>
        /// <param name="basic"></param>
        /// <returns></returns>
        private long ConvertToLongBySubstract(DateTime dt, DateTime basic)
        {
            TimeSpan tsStart = new TimeSpan(dt.Ticks);
            TimeSpan tsBasic = new TimeSpan(basic.Ticks);

            return Convert.ToInt64(tsStart.TotalSeconds - tsBasic.TotalSeconds);
        }

        public string ConvertToString(long datetime)
        {
            DateTime time = DateTime.Now;
            if (datetime > 0)
            {
                long longTime = datetime;
                time = new DateTime(1970, 1, 1);
                time = time.AddSeconds(longTime);
                return time.ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
                return string.Empty;
        }

    }
}
