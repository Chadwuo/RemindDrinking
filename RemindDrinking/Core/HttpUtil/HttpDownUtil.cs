using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace RemindDrinking.Core.HttpUtil
{
    public class HttpDownUtil
    {
        /**********************************************上传******************************************************/

        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }

        /**********************************************下载*******************************************************/
        /********************同步下载***************************/
        /// <summary>
        /// 同步下载
        /// Http下载文件
        /// </summary>
        public static string HttpDownloadFile(string url, string path)
        {

            var fi = new FileInfo(path);
            if (!Directory.Exists(fi.DirectoryName))
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }
            
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);

            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            // 发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            // 直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();

            // 创建本地文件写入流
            ////Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                //stream.Write(bArr, 0, size);
                fs.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }

            //stream.Close();
            fs.Close();
            responseStream.Close();

            return path;
        }


        /********************异步下载***************************/
        /// <summary>
        /// 异步回调
        /// </summary>
        /// <param name="result">Result.</param>
        private static void BeginResponseCallback(IAsyncResult result)
        {
            DownloadTmp downloadInfo = (DownloadTmp)result.AsyncState;
            HttpWebRequest Request = downloadInfo.WebRequest;
            HttpWebResponse Response = (HttpWebResponse)Request.EndGetResponse(result);

            if (Response.StatusCode == HttpStatusCode.OK || Response.StatusCode == HttpStatusCode.Created)
            {
                string filePath = downloadInfo.DownloadPath;


                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                //FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                FileStream fs = File.OpenWrite(filePath);

                Stream stream = Response.GetResponseStream();

                int count = 0;
                int num = 0;
                if (Response.ContentLength > 0)
                {
                    downloadInfo.AllContentLength = Response.ContentLength;
                    var buffer = new byte[2048 * 100];
                    do
                    {
                        num++;
                        count = stream.Read(buffer, 0, buffer.Length);
                        downloadInfo.CurrentContentLength = num * buffer.Length;
                        fs.Write(buffer, 0, count);
                        if (downloadInfo.LoadingCallback != null)
                        {
                            float pro = (float)fs.Length / Response.ContentLength * 100;
                            downloadInfo.LoadingCallback((int)pro);
                        }
                    } while (count > 0);
                }
                fs.Close();
                Response.Close();
                if (downloadInfo.SucceedCallback != null)
                {
                    downloadInfo.SucceedCallback();
                }
            }
            else
            {
                Response.Close();
                if (downloadInfo.FailedCallback != null)
                {
                    downloadInfo.FailedCallback();
                }
            }
        }

        /// <summary>
        /// 下载文件，异步
        /// </summary>
        /// <param name="URL">下载路径</param>
        /// <param name="downloadPath">文件下载路径</param>
        /// <returns></returns>
        public static void HttpDownloadFileAsyn(string URL, ref DownloadTmp downloadInfo)
        {
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
            downloadInfo.WebRequest = Request;
            Request.BeginGetResponse(BeginResponseCallback, downloadInfo);
        }
    }

    /// <summary>
    /// 下载请求信息
    /// </summary>
    public class DownloadTmp
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }


        /// <summary>
        /// 下载路径
        /// </summary>
        public string DownloadPath { get; set; }

        /// <summary>
        /// 下载进度回调
        /// </summary>
        public Action<int> LoadingCallback { get; set; }

        /// <summary>
        /// 完成回调
        /// </summary>
        public Action SucceedCallback { get; set; }

        /// <summary>
        /// 失败回调
        /// </summary>
        public Action FailedCallback { get; set; }

        /// <summary>
        /// webRequest
        /// </summary>
        public HttpWebRequest WebRequest { get; set; }

        public long AllContentLength { get; set; }

        public long CurrentContentLength { get; set; }
    }

}
