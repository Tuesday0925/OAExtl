using OAExtl;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;

namespace OAExtl.Handler
{
    /// <summary>
    /// GetItem_deal 的摘要说明
    /// </summary>
    public class RFI_RFQ_Picture_deal : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
            context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");

            context.Response.ContentType = "text/plain";
            //接收Ajax传入的参数


            string id = "250840";
            if (context.Request["id"] != null)
            {
                id = context.Request["id"].ToString();
            }




            //string path = @"D:\2024\1\0401\0d4105f7-38b2-47df-bbab-e08aeaad1c12.png";
            string path=string.Empty;               //压缩文件及路径
            string fileName=string.Empty;
            DBServer db = new DBServer();
            object objPath = db.GetSingle(DBServer.fw, @"SELECT A.filerealpath,A.filerealpath+REPLACE(RIGHT('F:\oafiles\files\202310\F\5b61d4cc-e522-4043-9535-9bcad731cf4e.zip',CHARINDEX('\',REVERSE('F:\oafiles\files\202310\F\5b61d4cc-e522-4043-9535-9bcad731cf4e.zip'))),'.zip','')AS cptp FROM dbo.ImageFile A  WHERE A.imagefileid="+id+"");

            if(objPath!=null)
            {
                path = @"" + objPath.ToString() + "";
                fileName= path.Substring(path.LastIndexOf('\\')+1,path.Length- path.LastIndexOf('\\')-1);
                fileName=fileName.Substring(0,fileName.LastIndexOf("."));
            }

            //已解压的路径
            string unzip_path = @"F:\测试\OAExtl\RepSales\Pic\" + fileName;

            //判断一下文件是否存在,不存在就解压
            if (File.Exists(unzip_path) == false)
            {

                //先解压
                ZipFile.ExtractToDirectory(path, @"F:\测试\OAExtl\RepSales\Pic\");
            }

            
            if (!string.IsNullOrEmpty(unzip_path))
            {

                FileStream filestream = new FileStream(unzip_path, FileMode.Open);

                Byte[] imageByte = new byte[filestream.Length];
                filestream.Read(imageByte, 0, imageByte.Length);//将图片数据读入比特数组存储

                string strphoto = Convert.ToBase64String(imageByte);


                context.Response.Write(strphoto);

                filestream.Close();
  
            }
            else
            {
                context.Response.Write("0");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}