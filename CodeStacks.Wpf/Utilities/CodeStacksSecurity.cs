using System;
using System.Security.Cryptography;
using System.Text;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    public class CodeStacksSecurity
    {
        /**
         * 注意：
         *      wpf中，PasswordBox有两个属性 
         *      Password、SecurePassword
         * **/

        /// <summary>
        /// 得到MD5值
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string pwd)
        {
            string hash = string.Empty;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5hash(md5Hash, pwd);
            }
            return hash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMd5hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 验证MD5值
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool VerifyMd5Hash(string input, string hash)
        {
            bool result = false;
            //string hashOfInput = string.Empty;
            //using (MD5 md5Hash = MD5.Create())
            //{
            //    hashOfInput = GetMd5hash(md5Hash, input);
            //}
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(input, hash))
                result = true;
            else
                result = false;
            return !result;
        }

    }
}
