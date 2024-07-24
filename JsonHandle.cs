using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data;

namespace OAExtl
{
    public class JsonHandle
    {
        public static string GetJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"page\":1,\"total\":" + dt.Rows.Count + ",\"records\":" + dt.Rows.Count + ",\"rows\"");
            jsonBuilder.Append(":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{\"id\":" + dt.Rows[i]["ID"].ToString() + ",\"cell\":[");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"","\\\"").Replace("\r","").Replace("\n","").Replace(">", "&gt;").Replace("<", "&lt;").Replace(" ", "&nbsp;").Replace("\"", "&quot;").Replace("\'", "&#39;").Replace("\\", "\\\\").Replace("	", ""));
                    jsonBuilder.Append("\",");
                }
                //jsonBuilder.Append("\"");
                //jsonBuilder.Append("<a href='../demo.htm' target='_blank'>链接</a>");
                //jsonBuilder.Append("\",");
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("]},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        public static string GetJson_url(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"page\":1,\"total\":" + dt.Rows.Count + ",\"records\":" + dt.Rows.Count + ",\"rows\"");
            jsonBuilder.Append(":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{\"id\":" + dt.Rows[i]["ID"].ToString() + ",\"cell\":[");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\"").Replace("\r", "").Replace("\n", ""));
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Append("\"");
                jsonBuilder.Append("<a href='Cust_ProductValue_Detail.aspx?ID=" + dt.Rows[i]["ID"].ToString() + "' target='_blank'>查看</a>");
                jsonBuilder.Append("\",");
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("]},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        public static string GetJson_url2(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"page\":1,\"total\":" + dt.Rows.Count + ",\"records\":" + dt.Rows.Count + ",\"rows\"");
            jsonBuilder.Append(":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{\"id\":" + dt.Rows[i]["ItemInfo_ItemID"].ToString() + ",\"cell\":[");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\"").Replace("\r", "").Replace("\n", ""));
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Append("\"");
                jsonBuilder.Append("<a href='LightingShipColl_Detail.aspx?flag=1&ID=" + dt.Rows[i]["ItemInfo_ItemID"].ToString() + "' target='_blank'>明细</a>");
                jsonBuilder.Append("\",");
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("]},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        public static string GetJson_url3(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"page\":1,\"total\":" + dt.Rows.Count + ",\"records\":" + dt.Rows.Count + ",\"rows\"");
            jsonBuilder.Append(":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{\"id\":" + dt.Rows[i]["OrderBy_Customer"].ToString() + ",\"cell\":[");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\"").Replace("\r", "").Replace("\n", ""));
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Append("\"");
                jsonBuilder.Append("<a href='LightingShipColl_Detail.aspx?flag=4&ID=" + dt.Rows[i]["OrderBy_Customer"].ToString() + "' target='_blank'>明细</a>");
                jsonBuilder.Append("\",");
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("]},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }


        public static string GetJson_url4(DataTable dt)
        {
            //StringBuilder jsonBuilder = new StringBuilder();
            //jsonBuilder.Append("{\"page\":1,\"total\":" + dt.Rows.Count + ",\"records\":" + dt.Rows.Count + ",\"rows\"");
            //jsonBuilder.Append(":[");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    jsonBuilder.Append("{\"id\":" + dt.Rows[i]["OrderBy_Customer"].ToString() + ",\"cell\":[");
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        jsonBuilder.Append("\"");
            //        jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\"").Replace("\r", "").Replace("\n", ""));
            //        jsonBuilder.Append("\",");
            //    }
            //    jsonBuilder.Append("\"");
            //    jsonBuilder.Append("<a href='VnCost_Detail.aspx?period=" + dt.Rows[i]["period"].ToString() + "&name=" + dt.Rows[i]["Code"].ToString() + "' target='_blank' style='text-decoration:underline'>明细</a>");
            //    jsonBuilder.Append("\",");
            //    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            //    jsonBuilder.Append("]},");
            //}
            //jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            //jsonBuilder.Append("]");
            //jsonBuilder.Append("}");
            //return jsonBuilder.ToString();


            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"page\":1,\"total\":" + dt.Rows.Count + ",\"records\":" + dt.Rows.Count + ",\"rows\"");
            jsonBuilder.Append(":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{\"id\":" + dt.Rows[i]["ID"].ToString() + ",\"cell\":[");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "").Replace(">", "&gt;").Replace("<", "&lt;").Replace(" ", "&nbsp;").Replace("\"", "&quot;").Replace("\'", "&#39;").Replace("\\", "\\\\").Replace("	", ""));
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Append("\"");
                jsonBuilder.Append("<a href='VnCost_Detail.aspx?period=" + dt.Rows[i]["Period"].ToString() + "&name=" + dt.Rows[i]["Code"].ToString() + "' target='_blank' style='text-decoration:underline'>明细</a>");
                jsonBuilder.Append("\",");
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("]},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();

        }


        public static string GetJsonMovementList(DataTable dt)
        {

            //[
            //    { "value": "1", "title": "李白" }
            //    , { "value": "2", "title": "杜甫" }
            //    , { "value": "3", "title": "苏轼" }
            //    , { "value": "4", "title": "李清照" }
            //    , { "value": "5", "title": "鲁迅"}
            //    , { "value": "6", "title": "巴金" }
            //    , { "value": "7", "title": "冰心" }
            //    , { "value": "8", "title": "矛盾" }
            //    , { "value": "9", "title": "贤心" }
            //]

            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].Caption.Trim().Replace("\"", "\\\"").Replace("\r", "").Replace("\n", ""));
                    jsonBuilder.Append("\":");
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\"").Replace("\r", "").Replace("\n", ""));
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }


        public static string GetJsonProcess(DataTable dt, int record)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"code\":0,\"msg\":\"\",\"count\":" + record + ",\"data\"");
            jsonBuilder.Append(":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].Caption.Trim().Replace("\"", "\\\"").Replace("\r", "").Replace("\n", ""));
                    jsonBuilder.Append("\":");
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\"").Replace("\r", "").Replace("\n", ""));
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
    }
}
