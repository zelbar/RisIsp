
$(document).ready(function () {
    var spData;
    $.get('/Contract/ServicePackages', function (data) {
        spData = data;
    });

    function getServicesCount() {
        return $('#services tbody tr').length;
    }

    function reIndex() {
        var idx = 0;
        $('#services tbody tr select.package').each(function() {
            $(this).attr('name', 'servicePackageIds[' + idx++ + ']');
        });
    }

    function reStart() {
        $('#services tbody button').on('click', function (evt) {
            $(evt.target).closest('tr').remove();
            reIndex();
        });

    }

    reStart();

    $('#services tfoot button').on('click', function () {
        $('#services tbody').append($('#services tfoot tr.hidden').clone());
        $('#services tbody tr.hidden').removeClass('hidden');
        reStart();
        reIndex();
    });

});