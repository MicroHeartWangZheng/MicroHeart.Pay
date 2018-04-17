using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Pay.Common.Util
{
    public class Tools
    {
        /// <summary>
        /// 获取TimeStamp
        /// </summary>
        /// <returns></returns>
        public static long GetTimestamp()
        {
            var startTime = TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1));

            return (long)(DateTime.UtcNow - startTime).TotalMilliseconds;
        }

        public static string GetMD5(string data)
        {
            using (var md5 =MD5.Create())
            {
                var hsah = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hsah).Replace("-", "");
            }
        }
    }
}
