using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace Pay.Common.Util
{
    public class Tools
    {
        /// <summary>
        /// 获取TimeStamp
        /// </summary>
        /// <returns></returns>
        public static string GetRandomString(int i = 1)
        {
            if (i == 1)
            {
                var startTime = TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1));

                return (DateTime.UtcNow - startTime).TotalMilliseconds.ToString();
            }
            else
            {
                return Guid.NewGuid().ToString("N");
            }
        }


        public static string GetMD5(string data)
        {
            using (var md5 = MD5.Create())
            {
                var hsah = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hsah).Replace("-", "");
            }
        }

        /// <summary>
        /// 将XML字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="xml">XML字符</param>
        /// <returns></returns>
        public static T DeserializeToObject<T>(string xml)
        {
            T myObject;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                myObject = (T)serializer.Deserialize(reader);
            }
            return myObject;
        }
    }
}
