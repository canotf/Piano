using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;

//System.Web.HttpContext.Current.

namespace Pinaol.Update {
    class Download {
        /// <summary>
        /// 用于缓存服务器端传输到客户端的SESSIONID或者JSESSIONID
        /// </summary>
        private Cookie sessionidCookie = null;

        /// <summary>
        /// 从HttpWebServer端获取文件(使用的是"post"方式)
        /// </summary>
        /// <param name="url">请求网址</param>
        /// <param name="data">请求参数集合，无需参数时传入null值</param>
        /// <param name="cookies">请求cookie集合，无需cookie时传入null值</param>
        /// <param name="fileSaveAddress">下载文件将要保存的位置(包括"文件名"."扩展名")</param>
        /// <returns>返回true代表成功，false代表失败</returns>
        public Boolean getFileFromHttpWebServer(String url, Hashtable data, CookieCollection cookies, String fileSaveAddress) {
            Boolean result = false;

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(fileSaveAddress)) {
                return false;//传入参数异常
            }
            byte[] data_stream = null;//将要向服务器传输的数据流内容
            if (data != null && data.Count > 0) {
                string transportData = "";//将要向服务器传输的字符串内容
                foreach (DictionaryEntry de in data) {
                    transportData = transportData + de.Key.ToString() + "=" + de.Value.ToString() + "&";//解调出键值对数据
                }
                transportData = transportData.TrimEnd('&');//去除字符串尾部的 &
                if (!string.IsNullOrEmpty(transportData)) {
                    data_stream = Encoding.UTF8.GetBytes(transportData);//将上传字符串数据打包成数据流
                }
            }


            try {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                //请求方式
                req.Method = "POST";
                //声明客户端接收任意类型的文件流
                req.Accept = "application/octet-stream";
                //以键值对形式向服务器传递参数
                req.ContentType = "application/x-www-form-urlencoded";
                //设置cookie盒子(客户端请求的cookie和服务器端返回的cookie就放在此盒子中)
                CookieContainer cookieContainer = new CookieContainer();
                if (sessionidCookie != null && !string.IsNullOrEmpty(sessionidCookie.Domain)) {
                    cookieContainer.Add(sessionidCookie);
                }
                if (cookies != null) {
                    cookieContainer.Add(cookies);//添加调用者传入的cookie集合
                }
                req.CookieContainer = cookieContainer;
                if (data_stream != null && data_stream.Length > 0) {
                    //请求数据流的长度
                    req.ContentLength = data_stream.Length;
                    using (Stream requestStream = req.GetRequestStream()) {
                        //写入请求实体流
                        requestStream.Write(data_stream, 0, data_stream.Length);
                    }
                }
                //接收返回值
                using (HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse()) {
                    if (myResponse.Cookies["SESSIONID"] != null) {
                        sessionidCookie = myResponse.Cookies["SESSIONID"];
                    } else {
                        if (myResponse.Cookies["JSESSIONID"] != null) {
                            sessionidCookie = myResponse.Cookies["JSESSIONID"];
                        }
                    }
                    ////下面为服务器端返回的下载文件名,留下作为参考用的
                    //if (myResponse.StatusCode == HttpStatusCode.OK)
                    //{
                    //    byte[] str = Encoding.GetEncoding("ISO-8859-1").GetBytes(myResponse.GetResponseHeader("Content-Disposition"));
                    //    string disposition = Encoding.UTF8.GetString(str);
                    //    Console.WriteLine("disposition：" + disposition);
                    //}
                    //流对象使用完后自动关闭
                    using (Stream stream = myResponse.GetResponseStream()) {
                        //文件流，流信息读到文件流中，读完关闭
                        using (FileStream fs = File.Create(fileSaveAddress)) {
                            //建立字节组，并设置它的大小是多少字节
                            byte[] bytes = new byte[10240];
                            int n = -1;
                            while ((n = stream.Read(bytes, 0, bytes.Length)) > 0) {
                                fs.Write(bytes, 0, n);　//将指定字节的流信息写入文件流中
                            }
                        }
                    }
                }

                result = true;//下载成功
            } catch (Exception e) {

            }

            return result;
        }


        /// <summary>
        /// 获得参数data的消息数据流，以"\r\n"结尾
        /// </summary>
        /// <param name="data">请求参数集合，无需参数时传入null值</param>
        /// <param name="boundary">消息分隔符</param>
        /// <returns>返回参数data的数据流，返回为空代表获得失败</returns>
        private byte[] getParameterBytes(Hashtable data, String boundary) {
            byte[] parameterBytes = null;

            //如果有请求参数
            if (data != null && data.Count > 0) {
                string parameterStr = "";
                foreach (DictionaryEntry de in data) {
                    parameterStr += "--" + boundary;
                    parameterStr += "\r\n" + "Content-Disposition: form-data;name=\"" + de.Key.ToString() + "\"";
                    parameterStr += "\r\n" + "Content-Type: text/plain; charset=UTF-8";
                    parameterStr += "\r\n\r\n" + de.Value.ToString();
                    parameterStr += "\r\n";
                }
                if (!string.IsNullOrEmpty(parameterStr)) {
                    parameterBytes = Encoding.UTF8.GetBytes(parameterStr);//将上传字符串数据打包成数据流
                }
            }

            return parameterBytes;
        }
        /// <summary>
        /// 获得上传文件的消息头部分字符流，以"\r\n\r\n"结尾
        /// </summary>
        /// <param name="de">上传文件《控件名,上传文件的保存位置(包括"文件名"."扩展名")》</param>
        /// <param name="boundary">消息分隔符</param>
        /// <returns>返回上传文件的消息头部分字符流，返回会为null代表获得失败</returns>
        private byte[] getUploadFileDeclareBytes(DictionaryEntry de, String boundary) {
            byte[] uploadFileDeclareBytes = null;

            //上传文件的消息头描述部分
            string uploadFileDeclareStr = "";
            uploadFileDeclareStr += "--" + boundary;
            uploadFileDeclareStr += "\r\n" + "Content-Disposition: form-data;name=\"" + de.Key.ToString() + "\"; filename=\"" + de.Value.ToString() + "\"";
            uploadFileDeclareStr += "\r\n" + "Content-Type: application/octet-stream";
            uploadFileDeclareStr += "\r\n\r\n";
            if (!string.IsNullOrEmpty(uploadFileDeclareStr)) {
                uploadFileDeclareBytes = Encoding.UTF8.GetBytes(uploadFileDeclareStr);//将上传字符串数据打包成数据流
            }


            return uploadFileDeclareBytes;
        }
    }
}
