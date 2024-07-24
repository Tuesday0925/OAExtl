//$.datepicker._gotoToday = function (id) {
//    var target = $(id);
//    var inst = this._getInst(target[0]);
//    if (this._get(inst, 'gotoCurrent') && inst.currentDay) {
//        inst.selectedDay = inst.currentDay;
//        inst.drawMonth = inst.selectedMonth = inst.currentMonth;
//        inst.drawYear = inst.selectedYear = inst.currentYear;
//    }
//    else {
//        var date = new Date();
//        inst.selectedDay = date.getDate();
//        inst.drawMonth = inst.selectedMonth = date.getMonth();
//        inst.drawYear = inst.selectedYear = date.getFullYear();
//        this._setDateDatepicker(target, date);
//        this._selectDate(id, this._getDateDatepicker(target));
//    }
//    this._notifyChange(inst);
//    this._adjustDate(target);
//}

//$(function () {
//    $(".ac_mGrid tbody tr").click(function () {
//        var i = $(this).index();
//        $(".ac_mGrid tbody").find('tr:eq(' + i + ')').addClass("s1").siblings().removeClass("s1");
//    });
//});


//$(function () {
//    $(".mGrid tbody tr").click(function () {
//        var i = $(this).index();
//        $(".mGrid tbody").find('tr:eq(' + i + ')').addClass("s1").siblings().removeClass("s1");
//    });
//});


//function Trim(str) {

//    return str.replace(/(^\s*)|(\s*$)/g, "");

//}


