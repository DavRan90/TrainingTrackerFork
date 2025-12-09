$(document).ready(function () {
    var activityDates = window.activityDates || [];

    $('#activity-calendar').datepicker({
        format: 'yyyy-mm-dd',
        todayHighlight: true,
        autoclose: false,
        startView: 0,
        multidate: false,
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        beforeShowDay: function (date) {
            var dateString = date.toISOString().split('T')[0];
            if (activityDates.includes(dateString)) {
                return { classes: 'activity-day', tooltip: 'Activity' };
            }
            return;
        }
    }).datepicker('show');
});
