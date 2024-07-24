using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using NPOI.SS.Formula.Functions;
using Antlr.Runtime.Misc;

namespace OAExtl.RepPP.handler
{
    /// <summary>
    /// Exp_CustomerInfo_deal 的摘要说明
    /// </summary>
    public class Cust_RFI_RFQ_deal : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        DBServer db = new DBServer();
        public void ProcessRequest(HttpContext context)
        {
            NameValueCollection forms = context.Request.Form;
            string strOperation = forms.Get("oper");

            //'org': org, 'ddlDate': ddlDate, 'date1': date1, 'date2': date2, 'ddlItem': ddlItem, 'ddlContion': ddlContion, 'item': item, 'bdbh': bdbh, 'ddlsfyfjspg': ddlsfyfjspg, 'ddldqzt': ddldqzt, 'ddlcpx': ddlcpx, 'flag': 0


            string org = "0";
            string ddlDate = "0";
            string date1 = DateTime.Now.Month.ToString() + "-01-01";
            string date2 = db.GetDateTimeMonthLastDay(DateTime.Now).ToString();

            string ddlItem = "0";
            string ddlContion = "0";
            string item = "";

            string bdbh = "";
            string ddlsfyfjspg = "";
            string ddldqzt = "";
            string ddlcpx = "";
            string flag = "0";

            DateTime dd;

            if (strOperation == null) //oper = null which means its first load.  
            {

                if (context.Request["org"] != null)
                {
                    org = context.Request["org"].ToString();
                }
                if (context.Request["ddlDate"] != null)
                {
                    ddlDate = context.Request["ddlDate"].ToString();
                }
                if (context.Request["date1"] != null)
                {
                    date1 = System.Web.HttpUtility.UrlDecode(context.Request["date1"].ToString(), System.Text.Encoding.UTF8);
                }
                if (context.Request["date2"] != null)
                {
                    date2 = System.Web.HttpUtility.UrlDecode(context.Request["date2"].ToString(), System.Text.Encoding.UTF8);
                }

                
                if (context.Request["ddlItem"] != null)
                {
                    ddlItem = System.Web.HttpUtility.UrlDecode(context.Request["ddlItem"].ToString(), System.Text.Encoding.UTF8);
                }
                if (context.Request["ddlContion"] != null)
                {
                    ddlContion = System.Web.HttpUtility.UrlDecode(context.Request["ddlContion"].ToString(), System.Text.Encoding.UTF8);
                }
                if (context.Request["item"] != null)
                {
                    item = System.Web.HttpUtility.UrlDecode(context.Request["item"].ToString(), System.Text.Encoding.UTF8);
                }
                if (context.Request["bdbh"] != null)
                {
                    bdbh = System.Web.HttpUtility.UrlDecode(context.Request["bdbh"].ToString(), System.Text.Encoding.UTF8);
                }

                if (context.Request["ddlsfyfjspg"] != null)
                {
                    ddlsfyfjspg = System.Web.HttpUtility.UrlDecode(context.Request["ddlsfyfjspg"].ToString(), System.Text.Encoding.UTF8);
                }
                if (context.Request["ddlcpx"] != null)
                {
                    ddlcpx = System.Web.HttpUtility.UrlDecode(context.Request["ddlcpx"].ToString(), System.Text.Encoding.UTF8);
                }
                if (context.Request["ddldqzt"] != null)
                {
                    ddldqzt = System.Web.HttpUtility.UrlDecode(context.Request["ddldqzt"].ToString(), System.Text.Encoding.UTF8);
                }

                if (context.Request["flag"] != null)
                {
                    flag = System.Web.HttpUtility.UrlDecode(context.Request["flag"].ToString(), System.Text.Encoding.UTF8);
                }









                //'org': org, 'ddlDate': ddlDate, 'date1': date1, 'date2': date2, 'ddlItem': ddlItem, 'ddlContion': ddlContion, 'item': item, 'bdbh': bdbh, 'flag': 0


                string sqlStrStart = "EXEC Cust_RFI_RFQ " + org + " ,'sqrq','" + date1 + "','" + date2 + "','" + ddlItem + "','" + ddlContion + "','" + item + "','" + bdbh + "','','','" + ddlcpx + "','" + ddlsfyfjspg + "','" + ddldqzt + "',0,0";

                context.Session["Cust_RFI_RFQ_sqlStrStart"] = sqlStrStart;
                //string sqlStrStart = "SELECT * FROM Z_Test";

                DataTable dt = db.GetDataSet(DBServer.fw,sqlStrStart).Tables[0];
                string jsonData = JsonHandle.GetJson(dt);


                //解压一下图片

                string path_name = string.Empty;               //压缩文件路径和名字
                string fileName = string.Empty;
                string suffixName=string.Empty; //后缀名
                string unzip_path_name=string.Empty; //解压的路径及文件名称
                string unzip_path= @"F:\OAExtl\RepSales\Pic\"; //解压的路径(测试)   
                SqlDataReader reader = db.GetReader(DBServer.fw, @"SELECT A.*,A2.imagefiletype,A2.filerealpath,REPLACE(REPLACE(RIGHT(A2.filerealpath,CHARINDEX('\',REVERSE(A2.filerealpath))),'.zip',''),'\','') AS filename,SUBSTRING(A2.imagefiletype,CHARINDEX('/',A2.imagefiletype)+1,LEN(A2.imagefiletype)-CHARINDEX('/',A2.imagefiletype)) AS Suffix FROM (SELECT id, REPLACE(SUBSTRING(cptp1, 1, CHARINDEX(',', cptp1)), ',', '') AS cptp1 FROM dbo.formtable_main_218_dt1  WHERE ISNULL(PicStream,'')='' AND CAST(ISNULL(cptp1,'') AS VARCHAR(200))<>'') A  JOIN dbo.DocImageFile A1 ON A.cptp1=A1.docid JOIN dbo.ImageFile A2 ON A1.imagefileid = A2.imagefileid");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["filerealpath"] != null)
                        {
                            path_name = @"" + reader["filerealpath"].ToString() + "";
                            fileName = reader["filename"].ToString();
                            suffixName = reader["Suffix"].ToString();
                        }

                        if (File.Exists(path_name))      //压缩文件是否存在
                        {
                            //已解压的路径
                            unzip_path_name = unzip_path + fileName;

                            //判断一下文件是否存在,不存在就解压
                            if (File.Exists(unzip_path_name) == false)
                            {

                                //先解压
                                ZipFile.ExtractToDirectory(path_name, unzip_path);

                                //重命名(加上后缀)
                                if (File.Exists(unzip_path + fileName + "." + suffixName) == false)
                                {
                                    File.Copy(unzip_path_name, unzip_path + fileName + "." + suffixName);
                                }
                            }
                        }
                    }
                }
                reader.Close();













                context.Response.Write(jsonData);//返回json数据


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