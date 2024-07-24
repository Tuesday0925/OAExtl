using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace OAExtl.Handler
{
    /// <summary>
    /// RFI_RFQ_PictureStream_deal 的摘要说明
    /// </summary>
    public class RFI_RFQ_PictureStream_deal : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
            context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");

            DBServer db = new DBServer();

            string path = string.Empty;               //路径及压缩档
            string fileName = string.Empty;           //文件名
            string unzip_path = string.Empty;  //解压路径
            int result = 0; //执行的行数

            string strsql = "SELECT A.*,filerealpath,REPLACE(REPLACE(RIGHT(A1.filerealpath,CHARINDEX('\\',REVERSE(filerealpath))),'.zip',''),'\\','') AS filename FROM (SELECT id, REPLACE(SUBSTRING(cptp1, 1, CHARINDEX(',', cptp1)), ',', '') AS cptp1 FROM dbo.formtable_main_218_dt1 ) A JOIN dbo.ImageFile A1 ON A.cptp1 = A1.imagefileid";

            SqlDataReader reader = db.GetReader(DBServer.fw, strsql);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string aaa = reader["filename"].ToString();

                    path = "" + reader["filerealpath"].ToString() + "";  //"F:\\oafiles\\files\\202310\\T\\24585490-5e08-4e1e-b3d0-c066d1bcec21.zip"
                    fileName = "" + reader["filename"].ToString() + "";

                    unzip_path = @"F:\oafiles_unzip\" + fileName;  //解压路径

                    //判断路径及压缩档是否存在
                    if (File.Exists(path))
                    {
                        //判断一下文件是否存在,不存在就解压
                        if (File.Exists(unzip_path) == false)
                        {
                            //先解压
                            ZipFile.ExtractToDirectory(path, @"F:\oafiles_unzip\");
                        }

                        if (!string.IsNullOrEmpty(unzip_path))
                        {

                            FileStream filestream = new FileStream(@"F:\oafiles_unzip\" + fileName, FileMode.Open);

                            Byte[] imageByte = new byte[filestream.Length];
                            filestream.Read(imageByte, 0, imageByte.Length);//将图片数据读入比特数组存储

                            string strphoto = Convert.ToBase64String(imageByte);

                            // strphoto  BASE64存入数据库
                            result += db.ExecuteOA("UPDATE formtable_main_218_dt1 SET PicStream='" + strphoto + "' WHERE id=" + reader["id"].ToString() + "");



                            filestream.Close();

                        }
                    }//判断路径是否存在
                }
            }
            reader.Close();
            
            context.Response.Write(result.ToString());






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