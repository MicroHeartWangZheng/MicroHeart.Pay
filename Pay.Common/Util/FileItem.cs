using System;
using System.IO;

namespace Pay.Common.Util
{
    /// <summary>
    /// 文件元数据。
    /// 可以使用以下几种构造方法：
    /// 本地路径：new FileItem("C:/temp.jpg");
    /// 本地文件：new FileItem(new FileInfo("C:/temp.jpg"));
    /// 字节流：new FileItem("abc.jpg", bytes);
    /// </summary>
    public class FileItem
    {
        private string FileName;
        private string MimeType;
        private byte[] Content;
        private FileInfo FileInfo;

        /// <summary>
        /// 基于本地文件的构造器。
        /// </summary>
        /// <param name="fileInfo">本地文件</param>
        public FileItem(FileInfo fileInfo)
        {
            if (fileInfo == null || !fileInfo.Exists)
            {
                throw new ArgumentException("fileInfo is null or not exists!");
            }
            this.FileInfo = fileInfo;
        }

        /// <summary>
        /// 基于本地文件全路径的构造器。
        /// </summary>
        /// <param name="filePath">本地文件全路径</param>
        public FileItem(string filePath)
            : this(new FileInfo(filePath))
        { }

        /// <summary>
        /// 基于文件名和字节流的构造器。
        /// </summary>
        /// <param name="fileName">文件名称（服务端持久化字节流到磁盘时的文件名）</param>
        /// <param name="content">文件字节流</param>
        public FileItem(string fileName, byte[] content)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            if (content == null || content.Length == 0)
                throw new ArgumentNullException("content");

            this.FileName = fileName;
            this.Content = content;
        }

        /// <summary>
        /// 基于文件名、字节流和媒体类型的构造器。
        /// </summary>
        /// <param name="fileName">文件名（服务端持久化字节流到磁盘时的文件名）</param>
        /// <param name="content">文件字节流</param>
        /// <param name="mimeType">媒体类型</param>
        public FileItem(String fileName, byte[] content, String mimeType)
            : this(fileName, content)
        {
            if (string.IsNullOrEmpty(mimeType))
                throw new ArgumentNullException("mimeType");
            this.MimeType = mimeType;
        }

        public string GetFileName()
        {
            if (this.FileName == null && this.FileInfo != null && this.FileInfo.Exists)
            {
                this.FileName = this.FileInfo.FullName;
            }
            return this.FileName;
        }

        public string GetMimeType()
        {
            if (this.MimeType == null)
            {
                this.MimeType = Utils.GetMimeType(GetContent());
            }
            return this.MimeType;
        }

        public byte[] GetContent()
        {
            if (this.Content == null && this.FileInfo != null && this.FileInfo.Exists)
            {
                using (Stream fileStream = this.FileInfo.OpenRead())
                {
                    this.Content = new byte[fileStream.Length];
                    fileStream.Read(Content, 0, Content.Length);
                }
            }
            return this.Content;
        }
    }
}
