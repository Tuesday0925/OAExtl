using System;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Security.Policy;


namespace OAExtl
{
    public class DBServer
    {
        public static string connectionString2 = "Data Source=192.168.0.10;Initial Catalog=ErpExtl;Persist Security Info=True;UID=pypypy;PWD=py123456;Max Pool Size=150;Connect Timeout=0;";
        //public static string connectionString_OA = "Data Source=192.168.0.11;Initial Catalog=OA100515;Persist Security Info=True;UID=sa;PWD=admin@123456;Max Pool Size=150;Connect Timeout=36000;";
        public static string connectionStringhr = "Data Source=192.168.0.15;Initial Catalog=MCHR;Persist Security Info=True;UID=sa;PWD=F8@ysR8PBYyGx;Max Pool Size=150;Connect Timeout=36000;";

        public static string fw = "Data Source=192.168.0.6;Initial Catalog=ecology;Persist Security Info=True;UID=sa;PWD=PYS1901.dbs;Max Pool Size=150;Connect Timeout=36000;";

        public static string erp = "Data Source=192.168.0.10;Initial Catalog=PYS18U9;Persist Security Info=True;UID=pypypy;PWD=py123456;Max Pool Size=150;Connect Timeout=36000;";

        public static string mes = "User Id=JZMES;Password=Aa654321;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=14.241.38.155)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl2)))";

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="username">操作用户</param>
        /// <param name="title">标题</param>
        /// <param name="org">组织</param>
        /// <param name="content">内容</param>
        public void insLog(string username, string title, string org, string content)
        {
            ExecuteSql("insert into base_log(username,IPA,title,Org,Content) values('" + username + "','" + HttpContext.Current.Request.UserHostName + "','" + title + "','" + org + "','" + content + "')");
        }

        public Int64 GetSigleStr(string strSql)
        {
            SqlConnection con = new SqlConnection(connectionString2);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(strSql, con);
            //object objRe=cmd.ExecuteScalar();

            Int64 objRe = 0;
            SqlDataReader sqlDr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (sqlDr.Read())
            {
                objRe = sqlDr.GetInt64(0);
            }
            sqlDr.Close();
            con.Close();

            return objRe;
            //if (objRe != null)
            //{
            //    return objRe.ToString();
            //}
            //else
            //{
            //    return "";
            //}

        }

        //public object GetSingle(string SQLString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                object obj = cmd.ExecuteScalar();
        //                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                connection.Close();
        //                throw new Exception(e.Message);
        //                //  ITNB.Base.Error.showError(e.Message.ToString());    
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //        }
        //    }
        //}

        //public object GetSingleOA(string SQLString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString_OA))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                object obj = cmd.ExecuteScalar();
        //                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                connection.Close();
        //                throw new Exception(e.Message);
        //                //  ITNB.Base.Error.showError(e.Message.ToString());    
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //        }
        //    }
        //}

        public object GetSingle2(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString2))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                        //  ITNB.Base.Error.showError(e.Message.ToString());    
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public bool IsInt(string s)
        {
            int i;
            if (int.TryParse(s, out i) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public SqlDataReader GetReader(string strSQL)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand(strSQL, connection);
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader myReader = cmd.ExecuteReader();
        //        return myReader;
        //    }
        //    catch (System.Data.SqlClient.SqlException e)
        //    {
        //        throw new Exception(e.Message);
        //        // ITNB.Base.Error.showError(e.Message.ToString());    
        //    }
        //    //finally //不能在此关闭，否则，返回的对象将无法使用    
        //    //{    
        //    //  cmd.Dispose();    
        //    //  connection.Close();    
        //    //}     

        //}

        public SqlDataReader GetReader2(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString2);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
                // ITNB.Base.Error.showError(e.Message.ToString());    
            }
            //finally //不能在此关闭，否则，返回的对象将无法使用    
            //{    
            //  cmd.Dispose();    
            //  connection.Close();    
            //}     

        }


        public string GetWeekday(string weekday)
        {
            string result = "";
            switch (weekday)
            {
                case "1":
                    result = "星期日";
                    break;
                case "2":
                    result = "星期一";
                    break;
                case "3":
                    result = "星期二";
                    break;
                case "4":
                    result = "星期三";
                    break;
                case "5":
                    result = "星期四";
                    break;
                case "6":
                    result = "星期五";
                    break;
                case "7":
                    result = "星期六";
                    break;
                default:
                    break;
            }
            return result;
        }

        //public SqlDataReader GetReaderOA(string strSQL)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString_OA);
        //    SqlCommand cmd = new SqlCommand(strSQL, connection);
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader myReader = cmd.ExecuteReader();
        //        return myReader;
        //    }
        //    catch (System.Data.SqlClient.SqlException e)
        //    {
        //        throw new Exception(e.Message);
        //        // ITNB.Base.Error.showError(e.Message.ToString());    
        //    }
        //    //finally //不能在此关闭，否则，返回的对象将无法使用    
        //    //{    
        //    //  cmd.Dispose();    
        //    //  connection.Close();    
        //    //}     

        //}


        //public DataSet GetDataSet(string SQLString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            connection.Open();
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.CommandText = SQLString;
        //            cmd.Connection = connection;
        //            cmd.CommandTimeout = 180;
        //            //SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
        //            SqlDataAdapter command = new SqlDataAdapter();
        //            command.SelectCommand = cmd;
        //            command.Fill(ds, "ds");
        //        }
        //        catch (System.Data.SqlClient.SqlException E)
        //        {
        //            throw new Exception(E.Message);
        //            //   ITNB.Base.Error.showError(E.Message.ToString());    
        //        }
        //        return ds;
        //    }
        //}

        public DataSet GetDataSet2(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString2))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = 180;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                    //   ITNB.Base.Error.showError(E.Message.ToString());    
                }
                return ds;
            }
        }

       


        //public DataSet GetDataSetOA(string SQLString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString_OA))
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            connection.Open();
        //            SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
        //            command.Fill(ds, "ds");
        //        }
        //        catch (System.Data.SqlClient.SqlException E)
        //        {
        //            throw new Exception(E.Message);
        //            //   ITNB.Base.Error.showError(E.Message.ToString());    
        //        }
        //        return ds;
        //    }
        //}


        //public int ExecuteSql_Erp(string SQLString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (System.Data.SqlClient.SqlException E)
        //            {
        //                connection.Close();
        //                throw new Exception(E.Message);
        //                //ITNB.Base.Error.showError(E.Message.ToString());    
        //            }
        //        }
        //    }
        //}

        public int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString2))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        cmd.CommandTimeout = 0;
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                        //ITNB.Base.Error.showError(E.Message.ToString());    
                    }
                }
            }
        }

        public int ExecuteOA(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(fw))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        cmd.CommandTimeout = 0;
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                        //ITNB.Base.Error.showError(E.Message.ToString());    
                    }
                }
            }
        }

        public int ExecuteSqlHr(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionStringhr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        cmd.CommandTimeout = 0;
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                        //ITNB.Base.Error.showError(E.Message.ToString());    
                    }
                }
            }
        }


        //public string GetDateFormat(string strfiled)
        //{
        //    if(strfiled.Contains("月")==true)
        //    {
        //        string[] rs=strfiled.Replace("月", "").Split('-');
        //        return rs[2]+"-"+"0"+rs[1]
        //    }
        //    //27-6月-2019


        //}




        /// <summary>
        /// 获取指定日期的月份第一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime GetDateTimeMonthFirstDay(DateTime dateTime)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }

            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// 获取指定月份最后一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime GetDateTimeMonthLastDay(DateTime dateTime)
        {
            int day = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            return new DateTime(dateTime.Year, dateTime.Month, day);
        }

        /// <summary>
        /// 获取本周第一天
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public DateTime GetWeekFirstDaySun(DateTime datetime)
        {
            //星期天为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (-1) * weeknow;

            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public double Todouble(string s)
        {
            double f = 0;
            double.TryParse(s.Trim(), out f);
            return f;
        }


        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="cols">第几列</param>
        public void GroupCol(GridView gridView, int cols)
        {
            if (gridView.Rows.Count < 1 || cols > gridView.Rows[0].Cells.Count - 1)
            {
                return;
            }
            TableCell oldTc = gridView.Rows[0].Cells[cols];
            for (int i = 1; i < gridView.Rows.Count; i++)
            {
                TableCell tc = gridView.Rows[i].Cells[cols];
                if (oldTc.Text == tc.Text)
                {
                    tc.Visible = false;
                    if (oldTc.RowSpan == 0)
                    {
                        oldTc.RowSpan = 1;
                    }
                    oldTc.RowSpan++;
                    oldTc.VerticalAlign = VerticalAlign.Middle;
                }
                else
                {
                    oldTc = tc;
                }
            }
        }


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="FromAddress">发件人地址</param>
        /// <param name="FromAddressPassword">发件人密码</param>
        /// <param name="ToAddress">收件人地址</param>
        /// <param name="CcAddress">抄送地址</param>
        /// <param name="SMTP">SMTP</param>
        /// <param name="Subject">标题</param>
        /// <param name="Content">内容</param>
        /// <param name="Attachment">附件</param>
        public void SendNetMail(string FromAddress, string FromAddressPassword, string[] ToAddress, string CcAddress, string SMTP, string Subject, string Content, string Attachment)
        {
            MailMessage mymail = new MailMessage();
            //发件人地址
            //如是自己，在此输入自己的邮箱
            mymail.From = new MailAddress(FromAddress);
            //收件人地址
            for (int i = 0; i < ToAddress.Length; i++)
            {
                string[] add = ToAddress[i].Split('|');


                mymail.To.Add(new MailAddress(add[0], add[1]));
            }
            //抄送到其他邮箱
            if (CcAddress != "")
            {
                mymail.CC.Add(new MailAddress(CcAddress));
            }
            //邮件主题
            mymail.Subject = Subject;
            //邮件标题编码
            mymail.SubjectEncoding = System.Text.Encoding.UTF8;
            //发送邮件的内容
            mymail.Body = Content;
            //邮件内容编码
            mymail.BodyEncoding = System.Text.Encoding.UTF8;
            //添加附件
            if (Attachment != "")
            {
                Attachment myfiles = new Attachment(Attachment);
                mymail.Attachments.Add(myfiles);
            }
            //是否是HTML邮件
            mymail.IsBodyHtml = true;
            //邮件优先级
            mymail.Priority = System.Net.Mail.MailPriority.High;
            //创建一个邮件服务器类
            SmtpClient myclient = new SmtpClient();
            myclient.Host = SMTP;
            //SMTP服务端口
            myclient.Port = 25;
            //验证登录
            myclient.Credentials = new NetworkCredential(FromAddress, FromAddressPassword);//"@"输入有效的邮件名, "*"输入有效的密码
            myclient.Send(mymail);
        }

      
        ///// <summary>
        ///// 获取单元格类型
        ///// </summary>
        ///// <param name="cell"></param>
        ///// <returns></returns>
        //private static object GetValueType(ICell cell)
        //{
        //    if (cell == null)
        //        return null;
        //    switch (cell.CellType)
        //    {
        //        case CellType.Blank: //BLANK:  
        //            return null;
        //        case CellType.Boolean: //BOOLEAN:  
        //            return cell.BooleanCellValue;
        //        case CellType.Numeric: //NUMERIC:  
        //            short format = cell.CellStyle.DataFormat;
        //            if (format != 0) { return cell.DateCellValue; } else { return cell.NumericCellValue; }
        //        case CellType.String: //STRING:  
        //            return cell.StringCellValue;
        //        case CellType.Error: //ERROR:  
        //            return cell.ErrorCellValue;
        //        case CellType.Formula: //FORMULA:  
        //        default:
        //            return "=" + cell.CellFormula;
        //    }
        //}


       

        public string getString(string s, int l, string endStr)
        {
            string temp = s.Substring(0, (s.Length < l) ? s.Length : l);

            if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= l)
            {
                return temp;
            }
            for (int i = temp.Length; i >= 0; i--)
            {
                temp = temp.Substring(0, i);
                if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= l - endStr.Length)
                {
                    return temp + endStr;
                }
            }
            return endStr;
        }


        public string getDocno(Int64 customer)
        {
            string Result = string.Empty;

            string code = string.Empty;

            object oCode = GetSingle2("select top 1 Code from (select A.Org,case A.Org when 1001712130000032 then '鹏元晟' else '宏润华' end AS OrgName,A.ID, A.Code, A1.Name, A2.Name AS Dept, A3.Name AS Assis, A5.Name AS ARName from PYS18U9.dbo.CBO_Customer A left join PYS18U9.dbo.CBO_Operators_Trl A1 on A.Saleser = A1.ID left join PYS18U9.dbo.CBO_Department_Trl A2 on A.Department = A2.ID left join PYS18U9.dbo.Base_User A3 on A.DescFlexField_PrivateDescSeg9 = A3.Code left join PYS18U9.dbo.CBO_ARConfirmTerm as A4 on A4.ID = A.ARConfirmTerm left join PYS18U9.dbo.CBO_ARConfirmTerm_Trl as A5 on (A5.SysMlFlag = 'zh-CN') and(A4.[ID] = A5.[ID]) where ISNULL(A.Code, '') <> '' union all select 1001712130000032 AS Org, '鹏元晟' aS OrgName, ID, Code, '' AS Name, Dept, '' AS Assis, '' AS ARName from Base_Customer where sing = 0 and IsNULL(Code, '') <> '') T where ID = " + customer);

            if (oCode != null)
            {
                code = oCode.ToString();
            }

            if (!string.IsNullOrEmpty(code))
            {
                code = code + "-QU" + DateTime.Now.ToString("yyyyMM");

                string SN = "001";
                try
                {
                    object oSN = GetSingle2("select SUBSTRING(cast(Max('1'+SUBSTRING(QuotationNo,len(QuotationNo)-2,3))+1 as varchar),2,3) from Quotation where QuotationNo like '" + code + "%' and QuotationNo not like '%-%'");
                    if (oSN != null)
                    {
                        SN = oSN.ToString();
                    }
                }
                catch { }

                code = code + SN;
            }

            if (!string.IsNullOrEmpty(code))
            {
                Result = code;
            }

            return Result;
        }



        public DataSet GetDataSetHr(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionStringhr))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = 180;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                    //   ITNB.Base.Error.showError(E.Message.ToString());    
                }
                return ds;
            }
        }


        //////////////////////////////      2019-07-11      /////////////////////////////////
        public SqlDataReader GetReader(string connectionString, string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
                // ITNB.Base.Error.showError(e.Message.ToString());    
            }
            //finally //不能在此关闭，否则，返回的对象将无法使用    
            //{    
            //  cmd.Dispose();    
            //  connection.Close();    
            //}     

        }

        public DataSet GetDataSet(string connectionString, string strSQL)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(strSQL, connection);
                    command.SelectCommand.CommandTimeout = 180;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                    //   ITNB.Base.Error.showError(E.Message.ToString());    
                }
                return ds;
            }
        }

        public int ExecuteSql(string connectionString, string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        cmd.CommandTimeout = 0;
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                        //ITNB.Base.Error.showError(E.Message.ToString());    
                    }
                }
            }
        }

        public object GetSingle(string connectionString, string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                        //  ITNB.Base.Error.showError(e.Message.ToString());    
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary> 
        /// 计算某日起始日期（礼拜一的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetMondayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }
        /// <summary> 
        /// 计算某日结束日期（礼拜日的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜日日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetSundayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Add(ts);
        }

        /// <summary>
        /// 获取所在周的日期
        /// </summary>
        /// <param name="someDate"></param>
        /// <returns></returns>
        public static string GetDatePeriod(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            someDate.Subtract(ts).ToString("MM月dd日");

            int j = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (j != 0) j = 7 - j;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。 
            TimeSpan ts2 = new TimeSpan(j, 0, 0, 0);
            return someDate.Subtract(ts).ToString("MM月dd日") + "-" + someDate.Add(ts2).ToString("MM月dd日");
        }

        public static string GetDateFormat(string s)
        {
            string result = s;
            s = s.Replace('.', '-').Replace('/', '-');

            string yy;
            string mm;
            string dd;

            if (s.Contains("-"))
            {

                string[] dates = s.Split('-');
                if (dates[1].Contains("月"))
                {
                    yy = dates[2];
                    mm = dates[1].Replace("月", "");
                    dd = dates[0];
                }
                else
                {
                    yy = dates[0];
                    mm = dates[1];
                    dd = dates[2];
                }

                if (int.Parse(mm) < 10)
                {
                    mm = "0" + mm;
                }
                if (int.Parse(dd) < 10)
                {
                    dd = "0" + int.Parse(dd).ToString();
                }
                result = yy + "-" + mm + "-" + dd;

            }

            return result;

        }


        public int compDate(string str1, string str2)
        {
            DateTime d1 = Convert.ToDateTime(str1);
            DateTime d2 = Convert.ToDateTime(str2);
            DateTime d3 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d1.Year, d1.Month, d1.Day));
            DateTime d4 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d2.Year, d2.Month, d2.Day));
            int days = (d4 - d3).Days;
            return days;
        }


        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public string GetWebClientIp()
        {

            string userIP = "0";

            try
            {
                if (System.Web.HttpContext.Current == null
                 || System.Web.HttpContext.Current.Request == null
                 || System.Web.HttpContext.Current.Request.ServerVariables == null)
                {
                    return "";
                }

                string CustomerIP = "";

                //CDN加速后取到的IP simone 090805
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!String.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                    if (CustomerIP == null)
                    {
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (string.Compare(CustomerIP, "unknown", true) == 0 || String.IsNullOrEmpty(CustomerIP))
                {
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                return CustomerIP;
            }
            catch { }

            return userIP;

        }


        public void InsertLog(string userid, string username, string title, string content, string url)
        {
            ExecuteSql("INSERT INTO Base_RptLog(UserID,Username,IPA,Title,Content,Url,Flag) VALUES('" + userid + "','" + username + "','" + GetWebClientIp() + "','" + title + "','" + content + "','" + url + "','ReportSystem')");
        }


        public string GetSerialNum(string productDate)
        {
            string result = "0";
            DateTime dTran;
            if (DateTime.TryParse(productDate, out dTran) == true)
            {
                object oResult = GetSingle2("SELECT MAX(SerialNum)+1 FROM QrCode_Main WHERE ProductDate=CAST('" + dTran + "' AS DATE)");
                if (oResult == null)
                {
                    result = dTran.ToString("yyyyMMdd") + "001";
                }
                else
                {
                    result = oResult.ToString();
                }
            }

            return result;
        }


        /// 程序执行时间测试
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
        public static double ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式
            return ts3.TotalMilliseconds;
        }


        public static DataTable RemoveDataTableNullColumns(DataTable dt)
        {
            foreach (var column in dt.Columns.Cast<DataColumn>().ToArray())
            {
                if (dt.AsEnumerable().All(dr => dr.IsNull(column)))
                    dt.Columns.Remove(column);
            }
            return dt;
        }



        /// <summary>
        /// 得到本周第一天(以星期一为第一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public DateTime GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一为第一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>
        /// 得到本周最后一天(以星期天为最后一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public DateTime GetWeekLastDaySun(DateTime datetime)
        {
            //星期天为最后一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);

            //本周最后一天
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        public string GetFormatDate(string s)
        {
            string result = s.Replace("月", "");
            string RegexStr = @"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$";



            string m = Regex.Match(result, RegexStr).ToString();

            if (!String.IsNullOrEmpty(m))
            {

                string[] dates = result.Split('-');

                if (dates.Length != 3)
                {
                    return result;
                }


                string yy = dates[2];
                string mm = dates[1];
                string dd = dates[0];


                if (yy.Length == 2)
                {
                    yy = "20" + yy;
                }

                if (mm.Length == 1)
                {
                    mm = "0" + mm;
                }
                if (dd.Length == 1)
                {
                    dd = "0" + dd;
                }
                result = yy + "-" + mm + "-" + dd;

            }


            else
            {






                s = s.Replace(".", "-").Replace("/", "-").Replace("年", "-").Replace("月", "-").Replace("日", "");

                if (s.Contains("-") == false)
                {
                    return result;
                }





            }





            return result;
        }


    }


}