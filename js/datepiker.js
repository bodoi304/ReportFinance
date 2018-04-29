$(function () {
    $.datepicker.regional['it'] = {
        monthNames: ['THÁNG 1', 'THÁNG 2', 'THÁNG 3', 'THÁNG 4', 'THÁNG 5', 'THÁNG 6', 'THÁNG 7', 'THÁNG 8', 'THÁNG 9', 'THÁNG 10', 'THÁNG 11', 'THÁNG 12'], // set month names
        dayNamesMin: ['CN','T2', 'T3', 'T4', 'T5', 'T6', 'T7'], // set more short days names
        dateFormat: 'dd/mm/yy' // set format date
    };

    $.datepicker.setDefaults($.datepicker.regional['it']);
    $(".datepicker,.datepicker1").datepicker({ dateFormat: 'dd/mm/yy'});
});