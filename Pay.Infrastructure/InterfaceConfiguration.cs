using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Infrastructure
{
    public class InterfaceConfiguration
    {
        /// <summary>
        /// 设置或获取第三方接口的AppId
        /// </summary>
        public string AppId { set; get; }
        /// <summary>
        /// 设置或获取第三方接口的安全码
        /// </summary>
        public string Secret { set; get; }
        /// <summary>
        /// 设置或获取第三方接口的ApiUrl
        /// </summary>
        public string ApiUrl { set; get; }
        /// <summary>
        /// 设置或获取第三方接口的MediaType
        /// </summary>
        public string MediaType { set; get; }
       
        /// <summary>
        /// 编码格式
        /// </summary>
        public string Charset { get; set; }
    }
}
