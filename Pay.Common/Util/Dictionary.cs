using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pay.Common.Util
{
    public static class Dictionary
    {
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
