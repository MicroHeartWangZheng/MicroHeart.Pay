using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Infrastructure
{
    public interface IUploadRequest : IRequest
    {
        /// <summary>
        /// 设置或获取上传的文件列表
        /// </summary>
        string[] file { set; get; }
    }
}
