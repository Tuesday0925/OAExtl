using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data.OleDb;
using NPOI.HSSF.UserModel;
using static ICSharpCode.SharpZipLib.Zip.ExtendedUnixData;
using NPOI.Util;
using NPOI.SS.Formula.Functions;

namespace OAExtl.RepSales
{
    public partial class Cust_RFI_RFQ :Page
    {
        DBServer db = new DBServer();
        public string StrDepartment = string.Empty;
        public string StrManager = string.Empty;
        public string StrSaler = string.Empty;
        public string StrCustomer = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (this.Session["username"] == null)
            //{
            //    this.Response.Write("<script language=javascript>alert('登陆超時！');window.parent.location = '../login.aspx?s=" + Request.Url.LocalPath + "'</script>");
            //    return;

            //}
            if (!Page.IsPostBack)
            {
                
                txtDate1.Text = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
                txtDate2.Text = DateTime.Now.ToString("yyyy-MM-dd");



                ddldqzt.DataSource = db.GetDataSet(DBServer.fw,"SELECT * FROM (SELECT '请选择当前状态' AS dqzt UNION SELECT DISTINCT dqzt FROM dbo.formtable_main_218) T ORDER BY CASE WHEN T.dqzt = '请选择当前状态' THEN 0 ELSE 1 END ").Tables[0];
                ddldqzt.DataValueField= "dqzt";
                ddldqzt.DataTextField = "dqzt";
                ddldqzt.DataBind();


                ddlcpx.DataSource = db.GetDataSet(DBServer.fw, "SELECT  0 id,'请选择产品线' name UNION SELECT id,name FROM dbo.uf_zdyxzk WHERE sslx='cpxlb'").Tables[0];
                ddlcpx.DataValueField = "name";
                ddlcpx.DataTextField = "name";
                ddlcpx.DataBind();

            }
        }

        

    

        //定义委托
        public delegate void GreetingDelegate();
        /// <summary>
        /// Gridview导出Excel
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="make">bind方法</param>
        /// <param name="xlsname">导出保存为文件的名称</param>
        public void ToExcel(GridView gv, GreetingDelegate make, string xlsname)
        {
            //gv.AllowPaging = false;
            //gv.Columns[7].Visible = false;
            make();
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            //下面这行很重要， attachment 参数表示作为附件下载，您可以改成 online在线打开
            //filename=FileFlow.xls 指定输出文件的名称，注意其扩展名和指定文件类型相符，可以为：.doc 　　 .xls 　　 .txt 　　.htm
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + xlsname + ".xls");
       
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Response.ContentType指定文件类型 可以为application/ms-excel、application/ms-word、application/ms-txt、application/ms-html 或其他浏览器可直接支持文档
            Response.ContentType = "application/ms-excel";
            this.EnableViewState = false;
            //　定义一个输入流
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            //gv.AllowPaging = false;
            gv.RenderControl(oHtmlTextWriter);
            //this 表示输出本页，你也可以绑定datagrid,或其他支持obj.RenderControl()属性的控件
            Response.Write(oStringWriter.ToString());
            Response.Flush();
            Response.End();
            //gv.AllowPaging = true;
            make();
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            //bind();
            //ToExcel(GridView1, bind, "OutPutValue" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }

        private void bind()
        {

        }


        public override void VerifyRenderingInServerForm(Control control) { }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            if(Session["Cust_RFI_RFQ_sqlStrStart"] ==null)
            {
                return;
            }

            



            
            string sqlStrStart = Session["Cust_RFI_RFQ_sqlStrStart"].ToString();
            DataTable dt = db.GetDataSet(DBServer.fw,sqlStrStart).Tables[0];


            dt.Columns.Remove("RealID");
            dt.Columns.Remove("requestid");

            dt.Columns.Remove("cptpID");
            dt.Columns.Remove("cptp1");
            
                
            //列标题
            string[] tableHeader = new string[] { "ID", "组织", "部门", "销售总监", "客户编码", "项目名称", "规格描述", "产品图片", "产品线", "项目等级", "年销售预测", "申请人", "申请日期", "需求日期", "是否需要研发技术评估", "成本估算(USD)", "当前状态", "备注", "表单编号", "标题", "节点", "节点人员" };



            //列宽
            int[] cellwidth = new int[] { 2000, 3000, 5000,
                3000, 3000, 3000, 4000,
                6000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000,
                3000, 3000, 3000, 3000, 3000, 3000, 3000
            };

            string fileName = "RFI/RFQ需求申请列表";

            MemoryStream ms = new MemoryStream();
            XSSFWorkbook workbook = new XSSFWorkbook();

            using (dt)
            {
                ISheet sheet = workbook.CreateSheet();
                //标题(合并单元格)
                ICellStyle style1 = workbook.CreateCellStyle();

                IFont font = workbook.CreateFont();
                font.FontHeightInPoints = 22;
                font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                font.FontName = "標楷體";
                style1.SetFont(font);//HEAD 样式
                style1.VerticalAlignment = VerticalAlignment.Center;
                style1.Alignment = HorizontalAlignment.Center;
                style1.WrapText = true;//自动换行

                //IRow dataRowt = sheet.CreateRow(0);  //创建行
                //dataRowt.CreateCell(0).SetCellValue("销售月出货计划"); //标题
                //dataRowt.Height = 512;
                //dataRowt.GetCell(0).CellStyle = style1;
                //// CellRangeAddress四个参数为：起始行，结束行，起始列，结束列
                //NPOI.SS.Util.CellRangeAddress sss = new NPOI.SS.Util.CellRangeAddress(0, 1, 0, 36);
                //sheet.AddMergedRegion(sss);


                IFont font2 = workbook.CreateFont();
                font2.FontHeightInPoints = 10;

                ICellStyle style0 = workbook.CreateCellStyle(); //边框 
                style0.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                style0.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style0.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                style0.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style0.VerticalAlignment = VerticalAlignment.Center;
                style0.Alignment = HorizontalAlignment.Center;
                style0.SetFont(font2);
                style0.WrapText = true;//自动换行

                ICellStyle style2 = workbook.CreateCellStyle(); //边框 
                style2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                style2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                style2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style2.SetFont(font2);
                style2.VerticalAlignment = VerticalAlignment.Center;
                style2.Alignment = HorizontalAlignment.Center;

                style2.FillForegroundColor = 22;
                style2.FillPattern = FillPattern.SolidForeground;
                style2.WrapText = true;//自动换行





                int ddd = dt.Columns.Count;

                //行标题
                IRow dataRow = sheet.CreateRow(0);
                //行标题
                if (tableHeader.Length > 0)
                {
                    for (int i = 0; i < tableHeader.Length; i++)
                    {
                        dataRow.CreateCell(i).SetCellValue(tableHeader[i].ToString());
                        dataRow.GetCell(i).CellStyle = style2;
                        dataRow.Height = 378;//行高
                        sheet.SetColumnWidth(i, cellwidth[i]);
                    }
                }



                double ftry;
                DateTime dtry;
                //表格内内容
                int rowIndex = 1;
                foreach (DataRow row in dt.Rows)
                {
                    dataRow = sheet.CreateRow(rowIndex);

                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.Ordinal == 7)
                        {
                            if (row[column] != null)
                            {
                                if (row[column].ToString() != "")
                                {
                                    dataRow.CreateCell(column.Ordinal).CellStyle = style0;  
                                    string picurl = row[column].ToString();  //图片存储路径        
                                    AddPieChart(sheet, workbook, picurl, rowIndex, 7);
                                    dataRow.Height = 2500;//行高

                                }
                                else
                                {
                                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                                    

                                }
                            }
                            else
                            {
                                dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                            }
                        }
                        else if(DateTime.TryParse(row[column].ToString(), out dtry) == true)
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue(DateTime.Parse(row[column].ToString()).ToString("yyyy-MM-dd"));
                        }
                        else if (double.TryParse(row[column].ToString(), out ftry) == true)
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue(double.Parse(row[column].ToString()));
                        }
                        else
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                        }

                        try
                        {
                            dataRow.GetCell(column.Ordinal).CellStyle = style0;
                        }
                        catch { }

                        

                    }

                    rowIndex++;
                }

                //sheet.SetColumnHidden(27, true);

                workbook.Write(ms);
                ms.Flush();

                //ms.Position = 0;


                SetExportFileName(fileName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx", workbook);
            }
            //end
            bind();

        }


        private void AddPieChart(ISheet sheet, XSSFWorkbook workbook, string fileurl, int row, int col)
        {
            //try
            //{
            //add picture data to this workbook.
            //string path = Server.MapPath("Pic/");
            string path = @"F:\OAExtl\RepSales\Pic\";
            //if (fileurl.Contains("/"))
            //{
            path += fileurl;
            //}
            string FileName = path;

            if (File.Exists(FileName))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(FileName);

                if (!string.IsNullOrEmpty(FileName))
                {
                    int pictureIdx = workbook.AddPicture(bytes, NPOI.SS.UserModel.PictureType.JPEG);
                    XSSFDrawing patriarch = (XSSFDrawing)sheet.CreateDrawingPatriarch();


                    XSSFClientAnchor anchor = new XSSFClientAnchor(2000, 1000, 40, 20,  col, row, col + 1, row + 1);
                    anchor.Dx1 = 1 * XSSFShape.EMU_PER_PIXEL;
                    anchor.Dy1 = 1 * XSSFShape.EMU_PER_POINT;
                    //##处理照片位置，【图片左上角为（col, row）第row+1行col+1列，右下角为（ col +1, row +1）第 col +1+1行row +1+1列，宽为100，高为50

                    XSSFPicture pict = (XSSFPicture)patriarch.CreatePicture(anchor, pictureIdx);

                    // pict.Resize();这句话一定不要，这是用图片原始大小来显示
                
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public static void SetExportFileName(string sFileName, XSSFWorkbook workbook)
        {
            System.Web.HttpContext.Current.Response.Charset = "GB2312";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            sFileName = System.Web.HttpUtility.UrlEncode(sFileName, System.Text.Encoding.UTF8);
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名 
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sFileName);
            // 指定返回的是一个不能被客户端读取的流，必须被下载 
            System.Web.HttpContext.Current.Response.ContentType = "application/ms-Excel";
            // 把文件流发送到客户端 
            workbook.Write(System.Web.HttpContext.Current.Response.OutputStream);
            // 停止页面的执行 
            System.Web.HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            int id = 0;

            int.TryParse(txtMid.Text.Trim(), out id);


            DateTime dd;

            //try
            //{
                
                    string strsql1 = "UPDATE dbo.formtable_main_218 SET dqzt='"+ ddlxdqzt.SelectedValue + "' WHERE id=(SELECT mainid FROM dbo.formtable_main_218_dt1 WHERE id="+id+")";

                  

                    db.ExecuteSql(DBServer.fw,strsql1);
                
            //}
            //catch (Exception ex)
            //{
            //    ShowMessage("系统异常:" + ex.ToString());
            //}



            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存成功');</script>");

        }

    }
}