<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cust_RFI_RFQ.aspx.cs" Inherits="OAExtl.RepSales.Cust_RFI_RFQ" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>RFI/RFQ需求申请列表</title>
    <link href="../Content/PubStyle.css" rel="stylesheet" />
    <link href="../Content/themes/base/jquery-ui_customer.css" rel="stylesheet" />
    <link href="../Content/jquery.jqGrid/ui.jqgrid.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts2/jquery-ui-1.10.4.min.js"></script>
    <script src="../Content/themes/base/jquery-ui.min.js"></script>
    <script src="../Scripts2/i18n/grid.locale-cn.js"></script>

    <script src="../Scripts2/jquery.jqGrid.min.js"></script>
    <script src="../Scripts2/public.js"></script>

    <link rel="stylesheet" href="../Content/themes/base/jquery.ui.datepicker.css" />
    <script type="text/javascript" src="../Scripts/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.ui.widget.js"></script>

    <!-- bootstrap -->
    <link href="../Content/bootstrap.css" rel="stylesheet"/>
    <script src="../Scripts/bootstrap.js"></script>

<%--    <link rel="stylesheet" href="../zoomify/zoomify.css" />--%>
<%--    <link rel="stylesheet" type="text/css" href="../js/zoom.css" />
    <script src="../js/zoom.js"></script>--%>



    <style>
        .content {
            width: 900px;
            margin: 0 auto;
            clear: both;
        }

            .content ul {
                list-style: none;
            }

            .content li {
                margin-top: 10px;
            }

        .margintop10 {
            margin-top: 5px;
        }

        .content span {
            text-align: left;
            background-color: #459e00;
            color: white;
            width: 140px;
        }

        .ui-pg-input {
            color: black;
        }

        .ui-pg-selbox {
            min-width: 50px;
            color: black;
        }


        input[type=text] {
            padding: 2px 1px;
        }


        .impformat td {
            border: 1px solid;
            padding: 4px 8px;
        }

        #table1 {
            border-collapse: collapse;
        }

        #ui-datepicker-div {
            z-index: 2500 !important;
        }





        .ui-jqgrid .ui-jqgrid-bdiv {
            border-top: 1px solid #E1E1E1;
            overflow-x: auto;
        }

        .frozen-div, .frozen-bdiv {
            background-color: #E4E6E9; /*与网页背景色一致*/
        }


        /*.ui-jqgrid .ui-jqgrid-title{font-size:22px;}*/ /*修改grid标题的字体大小*/

        /*.ui-jqgrid-sortable {font-size:32px;}*/ /*修改列名的字体大小*/

        /* .ui-jqgrid tr.jqgrow td {color:black;} */ /*修改表格内容字体*/

        th.ui-th-column div {
            white-space: normal !important;
            height: auto !important;
            padding: 0px;
        }

        .ui-jqgrid tr.jqgrow td {
            white-space: normal !important;
            height: auto;
            vertical-align: text-top;
            padding-top: 2px;
            word-break: break-all;
            vertical-align: middle;
        }

        .ui-widget-content {
            border: 1px solid #dfd9c3;
            /* background: #f5f3e5 url("images/ui-bg_highlight-hard_100_f5f3e5_1x100.png") 50% top repeat-x; */
            color: #312e25;
        }
    </style>


    <script type="text/javascript">


        $(function () {

            var org = $("#ddlOrg").val();
            var ddlDate = decodeURIComponent($("#ddlDate").val().trim());
            var date1 = decodeURIComponent($("#txtDate1").val().trim());
            var date2 = decodeURIComponent($("#txtDate2").val().trim());

            var ddlItem = decodeURIComponent($("#ddlItem").val().trim());
            var ddlContion = decodeURIComponent($("#ddlContion").val().trim());
            var item = decodeURIComponent($("#txtItem").val().trim());

            var bdbh = decodeURIComponent($("#txtBDBH").val().trim());

            var ddlsfyfjspg = decodeURIComponent($("#ddlsfyfjspg").val().trim());
            var ddldqzt = decodeURIComponent($("#ddldqzt").val().trim());
            var ddlcpx = decodeURIComponent($("#ddlcpx").val().trim());


            var PostData = {
                'org': org, 'ddlDate': ddlDate, 'date1': date1, 'date2': date2, 'ddlItem': ddlItem, 'ddlContion': ddlContion, 'item': item, 'bdbh': bdbh, 'ddlsfyfjspg': ddlsfyfjspg, 'ddldqzt': ddldqzt, 'ddlcpx': ddlcpx, 'flag': 0
            };

            jQuery("#list").jqGrid({
                url: 'Handler/Cust_RFI_RFQ_deal.ashx',
                datatype: "json",
                colNames: ["ID", "RealID", "requestid", "组织", "部门", "销售总监", "客户编码", "项目名称", "规格描述", "产品图片ID", "产品图片路径","产品图片", "产品线", "项目等级", "年销售预测", "申请人", "申请日期", "需求日期", "是否需要研发技术评估", "成本估算(USD)", "当前状态", "备注", "表单编号", "标题", "节点", "节点人员"],
                colModel: [
                    { name: 'ID', index: 'ID', width: 50, stype: 'text', align: 'center', sorttype: 'integer', cellattr: addCellAttr },

                    { name: 'RealID', index: 'requestid', width: 50, stype: 'text', align: 'center', sorttype: 'integer', frozen: true, cellattr: addCellAttr, hidden: true },
                    { name: 'requestid', index: 'requestid', width: 50, stype: 'text', align: 'center', sorttype: 'integer', frozen: true, cellattr: addCellAttr, hidden: true },

                    { name: 'Org', index: 'Org', width: 80, stype: 'text', align: 'center', sortable: true, cellattr: addCellAttr },
                    { name: 'SQRBM', index: 'SQRBM', width: 80, stype: 'text', align: 'center', sortable: true, cellattr: addCellAttr },
                    { name: 'xsfzr', index: 'xsfzr', width: 80, stype: 'text', align: 'center', sortable: true, cellattr: addCellAttr },
                    { name: 'khdm', index: 'khdm', width: 80, stype: 'text', align: 'center', sortable: true, cellattr: addCellAttr },
                    { name: 'xmmc', index: 'xmmc', width: 150, stype: 'text', align: 'center', sorttype: 'text', frozen: true, cellattr: addCellAttr },
                    { name: 'ggms1', index: 'ggms1', width: 250, stype: 'text', sortable: true, cellattr: addCellAttr },
                    { name: 'cptpID', index: 'cptpID', width: 150, stype: 'text', align: 'center', sortable: true, cellattr: addCellAttr, hidden: true },
                    { name: 'cptp1', index: 'cptp1', width: 150, stype: 'text', align: 'center', sortable: true, cellattr: addCellAttr, hidden: true },
                    { name: 'filename', index: 'filename', width: 200, stype: 'text', align: 'center', sortable: true, sorttype: "text", cellattr: addCellAttr, formatter: formatJpg },
                    { name: 'cpx', index: 'cpx', width: 120, stype: 'text', align: 'center', sortable: true, sorttype: "text", cellattr: addCellAttr },
                    { name: 'xmdj', index: 'xmdj', width: 80, stype: 'text', align: 'center', sorttype: 'text', sortable: true, cellattr: addCellAttr },
                    { name: 'nxslyc1', index: 'nxslyc1', width: 80, stype: 'text', align: 'center', sorttype: 'text', sortable: true, cellattr: addCellAttr },
                    { name: 'SQR', index: 'SQR', width: 80, stype: 'text', align: 'center', sortable: true, cellattr: addCellAttr },
                    { name: 'SQRQ', index: 'SQRQ', width: 80, sortable: true, sorttype: "date", formatter: "date", formatoptions: { srcformat: "Y-m-d", newformat: "Y-m-d" }, cellattr: addCellAttr },
                    { name: 'xqrq', index: 'xqrq', width: 80, stype: 'text', align: 'center', sortable: true, cellattr: addCellAttr },
                    { name: 'sfyfjspg', index: 'sfyfjspg', width: 80, stype: 'text', align: 'center', sorttype: 'text', sortable: true, cellattr: addCellAttr },
                    { name: 'cbgsusd', index: 'cbgsusd', width: 80, stype: 'text', align: 'center', sorttype: 'float', sortable: true, cellattr: addCellAttr },
                    { name: 'dqzt', index: 'dqzt', width: 80, stype: 'text', align: 'center', sorttype: 'text', sortable: true, cellattr: addCellAttr },
                    { name: 'bz', index: 'bz', width: 130, stype: 'text', sorttype: 'text', sortable: true, cellattr: addCellAttr },
                    { name: 'BDBH', index: 'BDBH', width: 120, stype: 'text', align: 'center', sortable: true, frozen: true, cellattr: addCellAttr },
                    { name: 'requestname', index: 'requestname', width: 120, stype: 'text', align: 'center', sortable: true, cellattr: addCellAttr },
                    { name: 'status', index: 'status', width: 80, stype: 'text', align: 'center', sortable: true, frozen: true, cellattr: addCellAttr },
                    { name: 'Person', index: 'Person', width: 100, stype: 'text', align: 'center', sortable: true, sorttype: "text", cellattr: addCellAttr },
                ],
                rowNum: 100,
                loadonce: true,
                rowList: [100, 200, 300],
                pager: '#pager',        //定义导航栏
                sortname: 'ID',
                viewrecords: true,      //是否显示记录总数
                rownumbers: true,
                shrinkToFit: false,
                autoScroll: true,
                width: "100%",
                autowidth: true,
                sortorder: 'ASC',
                footerrow: true,
                //caption: "客户列表",
                postData: PostData,
                editurl: 'Handler/Cust_RFI_RFQ_deal.ashx',
                loadComplete: function () {

                }
                , beforeRequest: function () {
                    //$("thead th").eq(5).css("text-align", "center").css("background", "#c34e18");
                    //$("thead th").eq(11).css("text-align", "center").css("background", "#c34e18");
                }
                , gridComplete: function () {

                    //$("#list").hideCol("DocID");
                    //$("#list").hideCol("ItemID");
                    //if ($("#txtAdit").val() == "1") {
                    //    $("#list").hideCol("ResultLocal");
                    //}



                    $('img').each(function (index, element) {

                       

                        // 此处的代码会对每个img元素执行
                        //console.log(index, $(element).attr('src')); // 输出图片的src属性

                        //var img = $(element);

                        //var maxWidth = 200; // 设置图片的最大宽度
                        //var maxHeight = 200; // 设置图片的最大高度

                        //var imgWidth = img.width();
                        //var imgHeight = img.height();

                        //var w;
                        //var h;

                        //if (imgWidth > imgHeight) {

                        //    w = maxWidth;
                        //    h = (maxWidth * imgHeight) / imgWidth;
                        //}
                        //else{
                           
                        //    w = maxHeight;
                        //    h = (maxHeight * imgWidth) / imgHeight;
                        //}
                        
                        
                        //img.width(w);
                        //img.height(h);
                       

                    });




                    //var org = $("#ddlOrg").val();
                    //var period = escape($("#txtPeriod").val().trim());
                    //var purer = escape($("#ddlPurer").val().trim());
                    //var code = escape($("#txtCode").val().trim());
                    //var shortname = escape($("#txtShortname").val().trim());


                    //var PostData1 = { 'org': org, 'period': period, 'purer': purer, 'code': code, 'shortname': shortname };

                    //$.post('Handler/Cust_DiffMny_Total_deal.ashx',
                    //    PostData1,
                    //    //回调函数
                    //    function (data) {
                    //        //输出结果
                    //        if (data != "") {

                    //            var combination = data.split(",");
                    //            $("#list").jqGrid("footerData", "set", {
                    //                ID: combination[0],
                    //                Org: "合计",
                    //                RcvQtyTU: combination[1],
                    //                FinallyPriceFC: combination[2],
                    //                DiffFinallyPriceFC: combination[3],
                    //                DiffMny: combination[4],
                    //                D6_FinallyPriceFC: combination[5],
                    //                D_FinallyPriceFC: combination[6]
                    //            });
                    //        }
                    //    },
                    //    //返回类型
                    //    "text"
                    //);



                    //var rows = $("#list").jqGrid("getRowData")

                    //var RcvQtyTU = 0;
                    //for (var i = 0, l = rows.length; i < l; i++) {
                    //    RcvQtyTU += (rows[i].RcvQtyTU - 0);
                    //}

                    //$("#list").jqGrid("footerData", "set", { Org: "--合计--", RcvQtyTU: RcvQtyTU });



                }
                //, loadComplete: function () {
                //    var ids = $("#list").getDataIDs();
                //    for (var i = 0; i < ids.length; i++) {
                //        $('#' + ids[i]).find("td").eq(14).css("color", "red");
                //        $('#' + ids[i]).find("td").eq(16).css("color", "blue");
                //        $('#' + ids[i]).find("td").eq(18).css("color", "red");
                //        $('#' + ids[i]).find("td").eq(20).css("color", "red");
                //    }
                //}
            });

            jQuery("#list").jqGrid('setFrozenColumns');
            $('#list').jqGrid('navGrid', '#pager',                          ///////////////////////////////////////////////////增删改
                {
                    edit: false,
                    add: false,
                    del: false,
                    search: true,
                    searchtext: "查找",
                    //addtext: "添加",
                    //edittext: "编辑",
                    //deltext: "删除",
                    refreshtext: "刷新"
                },
                {   //EDIT  
                    height: 420,
                    width: 600,
                    top: 50,
                    left: 100,
                    dataheight: 330,
                    closeOnEscape: true,//Closes the popup on pressing escape key  
                    //reloadAfterSubmit: true,
                    closeAfterEdit: true,
                    drag: true,
                    afterSubmit: function (response, postdata) {
                        if (response.responseText == "") {

                            $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid');//Reloads the grid after edit  
                            return [true, '']
                        }
                        else {
                            $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid'); //Reloads the grid after edit  
                            return [false, response.responseText]//Captures and displays the response text on th Edit window  
                        }
                    },
                    editData: {
                        EmpId: function () {
                            var sel_id = $('#list').jqGrid('getGridParam', 'selrow');
                            var value = $('#list').jqGrid('getCell', sel_id, 'ID');
                            return value;
                        }
                    },
                    afterComplete: function (response) {
                        if (response.responseText) {
                            close();
                            alert(response.responseText);
                        }
                    }
                },
                {      //添加
                    height: 420,
                    width: 600,
                    top: 50,
                    left: 100,
                    dataheight: 330,
                    reloadAfterSubmit: true,
                    closeAfterAdd: true,
                    afterSubmit: function (response, postdata) {

                        if (response.responseText == "") {

                            $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid')//Reloads the grid after Add  
                            return [true, '']
                        }
                        else {
                            $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid')//Reloads the grid after Add  

                            return [false, response.responseText]
                        }

                    }
                },
                {   //DELETE  
                    closeOnEscape: true,
                    closeAfterDelete: true,
                    reloadAfterSubmit: true,
                    drag: true,
                    afterSubmit: function (response, postdata) {
                        alert(response.responseText);
                        if (response.responseText == "") {

                            $("#list").trigger("reloadGrid", [{ current: true }]);
                            return [false, response.responseText]
                        }
                        else {
                            $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid')
                            return [true, response.responseText]
                        }

                    },
                    delData: {
                        EmpId: function () {
                            var sel_id = $('#list').jqGrid('getGridParam', 'selrow');
                            var value = $('#list').jqGrid('getCell', sel_id, 'ID');            //获取被删除的ID的值,ID是字段
                            return value;



                        }
                    }
                },
                {//SEARCH  
                    closeOnEscape: true

                }

            );

            function formatJpg(cellvalue, options, rowObject) {
                if (cellvalue == "") {
                    return "";
                }

                return "<img src='Pic/" + cellvalue + "' alt='" + cellvalue + "' width='200' height='200' data-action='zoom'/>";
                //style='max-height:200px; max-width:200px;'

                ////ajax start
                //$.ajax({
                //    type: "POST",
                //    url: "https://localhost:44376/Handler/RFI_RFQ_Picture_deal.ashx",
                //    dataType: "text",     //服务器返回类型   json如格式二
                //    data: { id: "250840" },
                //    success: function (data) {

                //       /* $("#Image1").attr("src", "data:image/png;base64," + data);*/


                //        /*var img = $('#Image1');*/ // 选择你要调整大小的图片
                //        var maxWidth = 200; // 设置图片最大宽度
                //        var maxHeight = 200; // 设置图片最大高度



                //        var imgWidth = img.width();
                //        var imgHeight = img.height();



                //        if (imgWidth > imgHeight) {

                //            imgWidth = maxWidth;
                //            imgHeight = (maxWidth * imgHeight) / imgWidth;
                //        }

                //        if (imgHeight > imgWidth) {

                //            imgWidth = maxHeight;
                //            imgHeight = (maxHeiht * imgWidth) / imgHeight;
                //        }

                //        if (value != null) {
                //            return "<img src=data:image/png;base64," + data + " width='" + imgWidth + "' height='" + imgHeight + "' />";
                //        } else {
                //            return "";
                //        }


                //    },
                //    error: function () {
                //        alert("错误");
                //    }
                //});
                ////ajax end



            }


            //jQuery("#ed1").click(function () {



            //    var rowid = $("#list").jqGrid("getGridParam", "selrow");

            //    var rowData = $("#list").jqGrid("getRowData", rowid);


            //    $("#txtMid").val(rowData.ID);


            //    if (typeof (rowData.ID) == "undefined") {
            //        alert("请选择编辑行");
            //        return false;
            //    }
            //    else {

            //        jQuery("#list").jqGrid('editRow', rowData.ID);
            //        this.disabled = 'true';
            //        jQuery("#sved1,#cned1").attr("disabled", false);
            //    }
            //});
            //jQuery("#sved1").click(function () {

            //    var ID = $("#txtMid").val();
            //    var rowData = $("#list").jqGrid("getRowData", ID);

            //    if (typeof (rowData.ID) != "undefined") {



            //        jQuery("#list").jqGrid('saveRow', rowData.ID);
            //        jQuery("#sved1,#cned1").attr("disabled", true);
            //        jQuery("#ed1").attr("disabled", false);

            //        var rowData1 = $("#list").jqGrid("getRowData", ID);

            //        var lineid = rowData1.LineID;
            //        var conclusion = rowData1.Conclusion;
            //        var cause = rowData1.Cause;


            //        var PostData1 = { 'lineid': lineid, 'conclusion': conclusion, 'cause': cause};

            //        $.post('Handler/Cust_QC_OQC_Result_update_deal.ashx',
            //            PostData1,
            //            //回调函数
            //            function (data) {
            //                //输出结果
            //                if (data != "0") {

            //                    //$("#list").jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid');
            //                }
            //            },
            //            //返回类型
            //            "text"
            //        );






            //    }
            //});
            //jQuery("#cned1").click(function () {
            //    var ID = $("#txtMid").val();
            //    jQuery("#list").jqGrid('restoreRow', ID);
            //    jQuery("#sved1,#cned1").attr("disabled", true);
            //    jQuery("#ed1").attr("disabled", false);
            //});




            //initTitle();


        });


        function initTitle() {

            //jQuery("#list").setGridParam().hideCol("MainID").trigger("reloadGrid");
            //jQuery("#list").setGridParam().hideCol("LineID").trigger("reloadGrid");
            //合并表头
            jQuery("#list").jqGrid('destroyGroupHeader');
            jQuery("#list").jqGrid('setGroupHeaders', {
                useColSpanStyle: true,
                groupHeaders: [
                    { startColumnName: 'D6_ConfirmDate', numberOfColumns: 2, titleText: "六个月前降价收货" },
                    { startColumnName: 'D_ConfirmDate', numberOfColumns: 2, titleText: "六个月内首次降价收货" }
                ]
            });
        }




        $(function () {

           
            

        })



        function test() {

            $('img').each(function (index, element) {
                // 此处的代码会对每个img元素执行
                var str = $(element).attr('id').replace("img_", "").split("_"); // 输出图片的src属性

                $.ajax({
                    type: "POST",
                    url: "https://localhost:44376/Handler/RFI_RFQ_Picture_deal.ashx",
                    dataType: "text",     //服务器返回类型   json如格式二
                    data: { id: str[0] },
                    success: function (data) {

                        $(element).attr("src", "data:image/png;base64," + data);


                        var img = $(element); // 选择你要调整大小的图片
                        var maxWidth = 200; // 设置图片最大宽度
                        var maxHeight = 200; // 设置图片最大高度



                        var imgWidth = img.width();
                        var imgHeight = img.height();



                        if (imgWidth > imgHeight) {

                            img.width(maxWidth);
                            img.height((maxWidth * imgHeight) / imgWidth);
                        }

                        if (imgHeight > imgWidth) {

                            img.height(maxHeight);
                            img.width((maxHeiht * imgWidth) / imgHeight);
                        }




                    },
                    error: function () {
                        alert("错误");
                    }
                });

            });


            return false;



         
        }

        //function SelectedRow() {

        //    var rowid = $("#list").jqGrid("getGridParam", "selrow");
        //    var rowData = $("#list").jqGrid("getRowData", rowid);

        //    window.returnValue = rowData.ID + "|" + rowData.Name + "|" + rowData.SPECS + "|" + rowData.Uom + "|" + rowData.Hprice + "|" + rowData.Price + "|" + rowData.Curreny + "|" + rowData.Supplier;
        //    window.close();
        //}

        function Query() {


            var org = $("#ddlOrg").val();
            var ddlDate = decodeURIComponent($("#ddlDate").val().trim());
            var date1 = decodeURIComponent($("#txtDate1").val().trim());
            var date2 = decodeURIComponent($("#txtDate2").val().trim());

            var ddlItem = decodeURIComponent($("#ddlItem").val().trim());
            var ddlContion = decodeURIComponent($("#ddlContion").val().trim());
            var item = decodeURIComponent($("#txtItem").val().trim());

            var bdbh = decodeURIComponent($("#txtBDBH").val().trim());

            var ddlsfyfjspg = decodeURIComponent($("#ddlsfyfjspg").val().trim());
            var ddldqzt = decodeURIComponent($("#ddldqzt").val().trim());
            var ddlcpx = decodeURIComponent($("#ddlcpx").val().trim());


            var PostData = {
                'org': org, 'ddlDate': ddlDate, 'date1': date1, 'date2': date2, 'ddlItem': ddlItem, 'ddlContion': ddlContion, 'item': item, 'bdbh': bdbh, 'ddlsfyfjspg': ddlsfyfjspg, 'ddldqzt': ddldqzt, 'ddlcpx': ddlcpx, 'flag': 0
            };

            jQuery("#list").jqGrid("clearGridData");
            $("#list").jqGrid('setGridParam', {
                url: "Handler/Cust_RFI_RFQ_deal.ashx",
                datatype: 'json',
                postData: PostData, //发送数据 
                page: 1
            }).trigger("reloadGrid"); //重新载入 
            //initTitle();
        }

        function closewin() {

            window.close();


        }


        $(function () {
            $("#list").setGridHeight($(window).height() - 180);

            $(window).resize(function () {
                $(window).unbind("onresize");
                $("#list").setGridHeight($(window).height() - 180);
                $("#list").setGridWidth($(window).width() - 25);

            });




        });


        function addCellAttr(rowId, val, rawObject, cm, rdata) {

            return "style='color:black;height:28px;border:1px solid #b4a570'";

        }



        function addCellAttr1(rowId, val, rawObject, cm, rdata) {

            return "style='color:black;border-top:1px solid #b4a570;border-bottom:1px solid #b4a570;border-right:2px solid #808080'";

        }





        //日历控件 start
        $(function () {

            $.datepicker.regional["zh-CN"] = { closeText: "关闭", prevText: "&#x3c;上月", nextText: "下月&#x3e;", currentText: "今天", monthNames: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"], monthNamesShort: ["一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二"], dayNames: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"], dayNamesShort: ["周日", "周一", "周二", "周三", "周四", "周五", "周六"], dayNamesMin: ["日", "一", "二", "三", "四", "五", "六"], weekHeader: "周", dateFormat: "yy-mm-dd", firstDay: 1, isRTL: !1, showMonthAfterYear: !0, yearSuffix: "年" }



            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);


            $("#txtDate1").datepicker({

                showOtherMonths: true,
                showButtonPanel: true,
                selectOtherMonths: true

            });
            $("#txtDate2").datepicker({

                showOtherMonths: true,
                showButtonPanel: true,
                selectOtherMonths: true

            });

            $("#txCustomerRequireDate").datepicker({

                showOtherMonths: true,
                showButtonPanel: true,
                selectOtherMonths: true

            });

            $("#txActualCompleteDate").datepicker({

                showOtherMonths: true,
                showButtonPanel: true,
                selectOtherMonths: true

            });

            $("#txCertificateDate").datepicker({

                showOtherMonths: true,
                showButtonPanel: true,
                selectOtherMonths: true

            });
        });
        //日历控件end



        function Add() {
            $("#lbl1").text("添加记录");
            $("#txtflag").val("0");


            $("#txCode").val("");
            $("#txSPECS").val("");
            $("#txOrderByQtyTU").val("");
            $("#txTotalMoneyTC").val("");
            $("#txSymbol").val("");


            $("#txEngineer").val("");
            $("#txCustomerRequireDate").val("");
            $("#txCertificateInfo").val("");
            $("#txCertificateBody").val("");
            $("#txCertificateDate").val("");
            $("#txActualCompleteDate").val("");


            $("#txCertificateSchedule1").val("");
            $("#txCertificateSchedule2").val("");
            $("#txCertificateSchedule3").val("");
            $("#txCertificateSchedule4").val("");
            $("#txMemo").val("");


            $("#myModal").modal("show");
        }

        function Edit() {

            var rowid = $("#list").jqGrid("getGridParam", "selrow");
            var rowData = $("#list").jqGrid("getRowData", rowid);


            //txkhdm txxmmc txggms1 txdqzt

            $("#txtMid").val(rowData.RealID);
            $("#txRealID").val(rowData.RealID);


            $("#txkhdm").val(rowData.khdm);
            $("#txxmmc").val(rowData.xmmc);
            $("#txggms1").val(rowData.ggms1);
            $("#ddlxdqzt").val(rowData.dqzt);





            if ($("#txtMid").val() == "" || typeof (rowData.RealID) == "undefined") {
                alert("请选择行!");
                return false;
            }
            $("#lbl1").text("编辑记录");
            $("#txtflag").val("1");
            $("#myModal").modal("show");
        }

        function SelDoc() {
            $("#myModal2").modal("show");
        }





        function Query2() {
            var name = decodeURIComponent($("#txtQuery2").val().trim());
            jQuery("#list2").jqGrid("clearGridData");
            $("#list2").jqGrid('setGridParam', {
                url: "Handler/Cust_QC_OQC_GetDoc_deal.ashx",
                datatype: 'json',
                postData: { 'name': name }, //发送数据 
                page: 1
            }).trigger("reloadGrid"); //重新载入 
        }


        function SelectedRow() {

            var rowid = $("#list2").jqGrid("getGridParam", "selrow");
            var rowData = $("#list2").jqGrid("getRowData", rowid);



            //txDocNo txDocLine  txCustomerCode txItemCode txName txSpec txUom txBusinessDate txDocQty txLine txDocID txItemID

            $("#txDocNo").val(rowData.DocNo);
            $("#txDocLine").val(rowData.DocLineNo);

            var itemcode = rowData.Code;

            if (itemcode.length > 3) {
                $("#txCustomerCode").val(itemcode.substring(0, 3));
            }
            $("#txItemCode").val(rowData.Code);
            $("#txName").val(rowData.Name);
            $("#txSpec").val(rowData.SPECS);
            $("#txUom").val(rowData.Uom);
            $("#txBusinessDate").val(rowData.BusinessDate);
            $("#txDocQty").val(rowData.ProductQty);
            $("#txDutyDept").val(rowData.DutyDept);
            $("#txLine").val(rowData.LineName);
            $("#txDocID").val(rowData.DocID);
            $("#txItemID").val(rowData.ItemMaster);
        }


        function checkNull() {
            if ($("#ddlxdqzt").val().trim() == "") {
                alert("请选择当前状态")
                return false;
            }
        }

        function Url() {
            window.open("Cust_RFI_RFQCol.aspx");
        }




    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div style="clear: both; display: block; border: 0px solid #742894; width: 100%; min-width: 1700px; float: left">
            <table style="height: 24px; width: 100%; ">
                <tr>
                    <td style="color:black; font-weight:normal">RFI/RFQ需求申请列表</td>
                </tr>
            </table>


            <table style="border-collapse: collapse; border: 1px solid #808080; min-width: 1600px; width: 100%; background: #F5F4EB;">

                <tr>

                    
                    <td style="width: 1500px; border-bottom: 1px solid #808080">
                        
                        <asp:TextBox ID="txtRealname" runat="server" Style="display: none;"></asp:TextBox>
                        <asp:TextBox ID="txtflag" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="txtAdit" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="txtMid" runat="server" Style="display: none"></asp:TextBox>
                        <asp:DropDownList ID="ddlOrg" runat="server" Style="display: none">
                            <asp:ListItem Text="请选择组织" Value="0"></asp:ListItem>
                            <asp:ListItem Text="鹏元晟" Value="1"></asp:ListItem>
                            <asp:ListItem Text="宏润华" Value="13"></asp:ListItem>
                            <asp:ListItem Text="衡元晟" Value="16"></asp:ListItem>
                            <asp:ListItem Text="越南分公司" Value="17"></asp:ListItem>
                        </asp:DropDownList>

                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlDate" runat="server">
                            <asp:ListItem Text="申请日期" Value="SQRQ"></asp:ListItem>
                        </asp:DropDownList>:
                        <asp:TextBox ID="txtDate1" runat="server" CssClass="border_Green" Text="" Width="100"></asp:TextBox>
                        至<asp:TextBox ID="txtDate2" runat="server" CssClass="border_Green" Text="" Width="100"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlItem" runat="server">
                            <asp:ListItem Text="标题" Value="0"></asp:ListItem>
                            <asp:ListItem Text="节点" Value="1"></asp:ListItem>
                            <asp:ListItem Text="节点人员" Value="2"></asp:ListItem>
                            <asp:ListItem Text="申请人" Value="3"></asp:ListItem>
                            <asp:ListItem Text="申请人部门" Value="4"></asp:ListItem>

                            <asp:ListItem Text="项目名称" Value="5"></asp:ListItem>
                            <asp:ListItem Text="规格描述" Value="6"></asp:ListItem>
                            <asp:ListItem Text="客户编码" Value="7"></asp:ListItem>
                            <asp:ListItem Text="销售总监" Value="8"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlContion" runat="server">
                            <asp:ListItem Text="包含" Value="0"></asp:ListItem>
                            <asp:ListItem Text="等于" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtItem" runat="server" CssClass="border_Green" Text=""></asp:TextBox>
                        &nbsp;&nbsp;
                        

                        表单编号:<asp:TextBox ID="txtBDBH" runat="server" CssClass="border_Green" Text="" Width="180"></asp:TextBox>
                        &nbsp;
                        <asp:DropDownList ID="ddlsfyfjspg" runat="server">
                            <asp:ListItem Text="是否需要研发技术评估" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            <asp:ListItem Text="否" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList ID="ddldqzt" runat="server">
                        </asp:DropDownList>
                        &nbsp;
                         <asp:DropDownList ID="ddlcpx" runat="server">
                         </asp:DropDownList>
                    </td>




                    <td style="height: 30px; border-bottom: 1px solid #808080">
                        <input id="Button1" type="button" value="查询" class="but-Green width60" onclick="Query()" />
                        &nbsp;&nbsp;
                       <%-- <input id="Button2" type="button" value="合格率统计" class="but-Green width80" onclick="Rate()" style="height: 24px; display: none" />
                        &nbsp;&nbsp;--%>
                        <asp:Button ID="btnExcel" runat="server" Text="导出" class="but-Green" Width="60px" OnClick="btnExcel_Click" />
                        &nbsp;
                        <input id="btnEdit" type="button" value="编辑" class="but-Green" style="vertical-align: middle; width: 60px" onclick="return Edit()" />

                        <%-- &nbsp;
                        <input id="btnAdd" type="button" value="新增" class="but-Green" style="vertical-align: middle; width: 60px; display: none" onclick="return Add()" />
                        
                        &nbsp;
                        <input id="btnUrl" type="button" value="分组统计" class="but-Green" style="vertical-align: middle; width: 80px" onclick="return Url()" />--%>

                    </td>
                </tr>
            </table>



            <table id="list" class="scroll" style="border-collapse: collapse;">
                <!--用于数据显示-->
            </table>
            <div id="pager" class="scroll" style="text-align: center;">
                <!--用于分页的层-->
            </div>




        </div>


        <!-- 模态框（Modal）新增 -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog" style="width: 1000px">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;</button>
                        <h4 class="modal-title" id="myModalLabel">
                            <label id="lbl1"></label>
                        </h4>
                    </div>
                    <div class="modal-body">
                        <!-- 内容1 -->

                        <%--          <div class="content">
                            <div style="width: 1000px; margin: 0 auto; clear: both; font-weight: bold; text-decoration: underline; padding-left: 10px">基本信息</div>
                            <div id="left" style="float: left; width: 450px;">
                                <div style="padding: 10px 10px; width: 450px">


                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">成品料号  <b style="color: red">*</b></span>
                                        <asp:TextBox ID="txCode" runat="server" class="form-control" Width="290"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">规格</span>
                                        <asp:TextBox ID="txSPECS" runat="server" class="form-control" Width="290"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">数量</span>
                                        <asp:TextBox ID="txOrderByQtyTU" runat="server" class="form-control" Width="290"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">金额  <b style="color: red">*</b></span>
                                        <asp:TextBox ID="txTotalMoneyTC" runat="server" class="form-control" Width="290"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">币别</span>
                                        <asp:TextBox ID="txSymbol" runat="server" class="form-control" Width="290"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <!--left-->

                            <div id="right" style="float: right; width: 450px;">
                                <div style="padding: 10px 10px; width: 450px">
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">认证工程师 <b style="color: red">*</b></span>
                                        <asp:TextBox ID="txEngineer" runat="server" class="form-control" Width="150"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">客户需求日期</span>
                                        <asp:TextBox ID="txCustomerRequireDate" runat="server" class="form-control" Width="290" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">证书讯息(品牌,型号)</span>
                                        <asp:TextBox ID="txCertificateInfo" runat="server" class="form-control" Width="290" autocomplete="off"></asp:TextBox>
                                    </div>

                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">认证机构</span>
                                        <asp:TextBox ID="txCertificateBody" runat="server" class="form-control" Width="290" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">认证需求完成日 <b style="color: red">*</b></span>
                                        <asp:TextBox ID="txCertificateDate" runat="server" class="form-control" Width="290" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">实际完成日 <b style="color: red">*</b></span>
                                        <asp:TextBox ID="txActualCompleteDate" runat="server" class="form-control" Width="290" autocomplete="off"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <!--left-->
                        </div>
                        <!-- 内容1 end -->--%>


                        <!-- 内容2 -->
                        <div style="width: 900px; margin: 0 auto; clear: both; font-weight: bold; text-decoration: underline; padding-left: 10px">编辑当前状态</div>
                        <div class="content">
                            <div id="left3" style="float: left; width: 900px;">
                                <div style="padding: 10px 10px; width: 900px">

                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">ID</span>
                                        <asp:TextBox ID="txRealID" runat="server" class="form-control" Width="600" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">客户编码</span>
                                        <asp:TextBox ID="txkhdm" runat="server" class="form-control" Width="600" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">项目名称</span>
                                        <asp:TextBox ID="txxmmc" runat="server" class="form-control" Width="600" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">规格描述</span>
                                        <asp:TextBox ID="txggms1" runat="server" class="form-control" Width="600" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="input-group input-group-sm margintop10">
                                        <span class="input-group-addon" style="width: 140px">当前状态 <b style="color: red">*</b></span>
                                        <asp:DropDownList ID="ddlxdqzt" runat="server" class="form-control">
                                            <asp:ListItem Value="" Text="请选择当前状态"></asp:ListItem>
                                            <asp:ListItem Value="需求申请" Text="需求申请"></asp:ListItem>
                                            <asp:ListItem Value="研发评估" Text="研发评估"></asp:ListItem>
                                            <asp:ListItem Value="RFI估算成本" Text="RFI估算成本"></asp:ListItem>
                                            <asp:ListItem Value="报价申请" Text="报价申请"></asp:ListItem>
                                            <asp:ListItem Value="样品申请" Text="样品申请"></asp:ListItem>
                                            <asp:ListItem Value="立项申请" Text="立项申请"></asp:ListItem>
                                            <asp:ListItem Value="量产" Text="量产"></asp:ListItem>
                                            <asp:ListItem Value="商务暂停" Text="商务暂停"></asp:ListItem>
                                            <asp:ListItem Value="商务终止" Text="商务终止"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>
                            <!--left-->


                        </div>
                        <!-- 内容2 end -->


                        <!--- content end-->



                        <div class="modal-footer" style="text-align: center; clear: both; width: 100%;">
                            <asp:Button ID="btnOk" class="btn btn-primary" runat="server" Text="确定" OnClick="btnOk_Click" Height="30" OnClientClick="return checkNull()" />
                            <button type="button" class="btn btn-default" data-dismiss="modal" style="height: 30px">
                                关闭
                            </button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal -->
            </div>
        </div>
        <!-- myModal -->



        <!-- 模态框（Modal） -->
        <div class="modal fade" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog" style="width: 910px">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;
                        </button>
                        <h4 class="modal-title">请选择单号
                        </h4>
                    </div>
                    <div class="modal-body">
                        <input id="txtQuery2" name="txtQuery" type="text" style="border: 1px solid #0c6028; width: 200px; vertical-align: middle" />
                        <input id="btnQuery2" name="btnQuery" type="button" value="查询" onclick="Query2()" style="border: 1px solid #707070; vertical-align: middle" />
                        <table id="list2" class="scroll" style="border-collapse: collapse;">
                            <!--用于数据显示-->
                        </table>
                        <div id="pager2" class="scroll" style="text-align: center;">
                            <!--用于分页的层-->
                        </div>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="SelectedRow()" style="height: 28px; padding-top: 4px; padding-bottom: 4px">
                            确定
                        </button>
                        <button type="button" class="btn btn-default" data-dismiss="modal" style="height: 28px; padding-top: 4px; padding-bottom: 4px">
                            关闭
                        </button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal -->
        </div>
        <!-- 模态框（Modal） end-->

    </form>
</body>
</html>
