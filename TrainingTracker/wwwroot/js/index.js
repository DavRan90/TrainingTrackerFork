$(document).ready(function () {

    // Se till att elementet finns
    var $calendar = $('#activity-calendar');
    if ($calendar.length === 0) {
        return; 
    }

    // Hämta datumen från globala variabeln (som vi satte i cshtml)
    var activityDates = window.activityDates || [];

    $calendar.datepicker({
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
