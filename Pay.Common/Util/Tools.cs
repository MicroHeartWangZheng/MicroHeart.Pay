using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
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
        /// 将XML字符串转为Json
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="xml">XML字符</param>
        /// <returns></returns>
        public static string XmlToJson(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                throw new ArgumentNullException(nameof(xml));

            var parameters = new Dictionary<string, object>();

            var doc = XDocument.Parse(xml).Root;
            var text = doc.DescendantNodes().OfType<XText>().ToList();
            foreach (var t in text)
            {
                parameters.Add(t.Parent.Name.LocalName, t.Value);

                // 移除CData
                if (t is XCData)
                {
                    t.Parent.Add(t.Value);
                    t.Remove();
                }
            }

            var jsonText = JsonConvert.SerializeXNode(doc);
            var json = JsonConvert.DeserializeObject<IDictionary>(jsonText);
            if (json != null)
            {
                // 忽略根节点的名称
                foreach (var key in json.Keys)
                {
                    return json[key].ToString();
                }
            }
            return null;
        }

        /// <summary>
        /// 将XML字符串序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="xml">XML字符</param>
        /// <returns></returns>

        public static T XmlToObject<T>(string xml)
        {
            if (xml != null)
            {
                return JsonConvert.DeserializeObject<T>(XmlToJson(xml));
            }
            return default(T);
        }

        /// <summary>
        /// 将xml转化为字典
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static IDictionary<string, object> XmlToDictionary(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new Exception("xml是null.");
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                dic[xe.Name] = xe.InnerText;//获取xml的键值对到WxPayData内部的数据中
            }
            return dic;
        }
    }
}
