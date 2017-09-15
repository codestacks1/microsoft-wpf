using System;
using System.Threading;

namespace Xiaowen.CodeStacks.Data.Models.CodeStacks
{
    public class CareMe
    {
        public int WWW { get; set; }

        public int GitHub { get; set; }

        public int Com { get; set; }

        private int CodeStacks1 { get; set; }

        public int GiveMe { get; set; }


        #region Delegate

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "isStart" ></ param >
        public Action<string> TimerFriend
        {
            get { return CheckNetWork; }
            private set { }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name = "configParam" ></ param >
        public Action<string[]> ConfigFriend
        {
            get { return CheckMeConfig; }
            private set { }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name = "selfObject" ></ param >
        public Action<object[]> MyFriend
        {
            get { return CheckMe; }
            private set { }
        }

        #endregion


        #region Function
        /// <summary>
        /// 运行时检查，检查对象是否存在
        /// 不存在，使程序持续退出
        /// 存在，则正常运行
        /// </summary>
        /// <param name="param"></param>
        public void CheckMe(params object[] param)
        {
            bool isExit = false;
            if (isExit)
            {

            }
            else
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 检查配置文件中的内容是否符合设定的值，
        /// 不符合，程序退出
        /// 存在，正常运行
        /// </summary>
        /// <param name="configKeys"></param>
        public void CheckMeConfig(params string[] configKeys)
        {
            bool isExit = false;
            if (isExit)
            {

            }
            else
            {
                Environment.Exit(0);
            }
        }

        Timer timer;
        /// <summary>
        /// 检查网络是否可用，
        /// 若网络不可用：定时退出软件
        /// 否则：软件持续可用
        /// </summary>
        /// <param name="isStart"></param>
        public void CheckNetWork(string isStart)
        {
            //isStart决定是否启用该功能
            if ("1".Equals(isStart.Trim()))
            {
                //时钟线程
                timer = new Timer((obj) =>
                {
                    string curDt =
                    DateTime.Now.ToShortTimeString();
                    if ("16:00".Equals(curDt))
                    {
                        //到达时间点，退出当前系统
                        Environment.Exit(0);
                    }
                }, null, 10, 1000);
            }
            else
            {
                bool flag = false;
                if (flag)
                {

                }
            }
        }
        #endregion

    }
}
