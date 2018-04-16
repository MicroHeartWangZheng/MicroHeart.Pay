using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Pay.Common.Util
{
    public static class Utils
    {

        /// <summary>m>
        /// <param name="bizContent"></param>
        /// <param name="charset"></param>
        ///  AES加密
        /// </summary>
        /// <param name="encryptKey"></para
        /// <returns></returns>
        public static string AesEncrypt(string encryptKey, string bizContent, string charset)
        {
            return Encrypt.AesEncrypt(encryptKey, bizContent, charset);

        }

        /// <summary>
        /// 清除字典中值为空的项。
        /// </summary>
        /// <param name="dict">待清除的字典</param>
        /// <returns>清除后的字典</returns>
        public static IDictionary<string, T> CleanupDictionary<T>(IDictionary<string, T> dict)
        {
            IDictionary<string, T> newDict = new Dictionary<string, T>(dict.Count);
            IEnumerator<KeyValuePair<string, T>> dem = dict.GetEnumerator();

            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                T value = dem.Current.Value;
                if (value != null)
                {
                    newDict.Add(name, value);
                }
            }
            return newDict;
        }

        /// <summary>
        /// 获取文件的真实后缀名。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData">文件字节流</param>
        /// <returns>JPG, GIF, PNG or null</returns>
        public static string GetFileSuffix(byte[] fileData)
        {
            if (fileData == null || fileData.Length < 10)
            {
                return null;
            }

            if (fileData[0] == 'G' && fileData[1] == 'I' && fileData[2] == 'F')
            {
                return "GIF";
            }
            else if (fileData[1] == 'P' && fileData[2] == 'N' && fileData[3] == 'G')
            {
                return "PNG";
            }
            else if (fileData[6] == 'J' && fileData[7] == 'F' && fileData[8] == 'I' && fileData[9] == 'F')
            {
                return "JPG";
            }
            else if (fileData[0] == 'B' && fileData[1] == 'M')
            {
                return "BMP";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取文件的真实媒体类型。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData">文件字节流</param>
        /// <returns>媒体类型</returns>
        public static string GetMimeType(byte[] fileData)
        {
            string suffix = GetFileSuffix(fileData);
            string mimeType;

            switch (suffix)
            {
                case "JPG": mimeType = "image/jpeg"; break;
                case "GIF": mimeType = "image/gif"; break;
                case "PNG": mimeType = "image/png"; break;
                case "BMP": mimeType = "image/bmp"; break;
                default: mimeType = "application/octet-stream"; break;
            }
            return mimeType;
        }

        /// <summary>
        /// 根据文件后缀名获取文件的媒体类型。
        /// </summary>
        /// <param name="fileName">带后缀的文件名或文件全名</param>
        /// <returns>媒体类型</returns>
        public static string GetMimeType(string fileName)
        {
            string mimeType;
            fileName = fileName.ToLower();

            if (fileName.EndsWith(".bmp", StringComparison.CurrentCulture))
            {
                mimeType = "image/bmp";
            }
            else if (fileName.EndsWith(".gif", StringComparison.CurrentCulture))
            {
                mimeType = "image/gif";
            }
            else if (fileName.EndsWith(".jpg", StringComparison.CurrentCulture) || fileName.EndsWith(".jpeg", StringComparison.CurrentCulture))
            {
                mimeType = "image/jpeg";
            }
            else if (fileName.EndsWith(".png", StringComparison.CurrentCulture))
            {
                mimeType = "image/png";
            }
            else
            {
                mimeType = "application/octet-stream";
            }

            return mimeType;
        }

        /// <summary>
        /// 根据API名称获取响应根节点名称。
        /// </summary>
        /// <param name="api">API名称</param>
        /// <returns></returns>
        public static string GetRootElement(string api)
        {
            int pos = api.IndexOf(".");
            if (pos != -1 && api.Length > pos)
            {
                api = api.Substring(pos + 1).Replace('.', '_');
            }
            return api + "_response";
        }

        /// <summary>
        /// 获取TimeStamp
        /// </summary>
        /// <returns></returns>
        public static long GetTimestamp()
        {
            var startTime = TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1));

            return (long)(DateTime.UtcNow - startTime).TotalMilliseconds;
        }

        /// <summary>
        /// 将指定的字典转换成按属性名称排序过的查询参数
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="urlencode"></param>
        /// <param name="exclude">排除的参数</param>
        /// <returns></returns>
        public static string DictionaryToSortQueryParameters(this IDictionary<string, object> dict, bool urlencode = false, params string[] exclude)
        {
            var sortDict = dict.OrderBy(m => m.Key).Select(m =>
            {
                if (m.Value == null || exclude.Contains(m.Key))
                    return null;
                var val = m.Value.ToString();
                var encodeVal = "";
                if (urlencode)
                {
                    encodeVal += HttpUtility.UrlEncode(val.ToString());
                }
                else
                {
                    encodeVal = val;
                }
                return $"{m.Key}={encodeVal}";
            }).Where(m => m != null);
            var result = string.Join("&", sortDict.ToArray());
            return result;
        }
    }
}
