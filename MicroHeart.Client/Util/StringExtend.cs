using System;
using System.Security.Cryptography;
using System.Text;

namespace MicroHeart.Client.Util
{
    public static class StringExtend
    {
        public static string ToMD5(this string data)
        {
            using (var md5 = MD5.Create())
            {
                var hsah = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hsah).Replace("-", "");
            }
        }

    }
}
