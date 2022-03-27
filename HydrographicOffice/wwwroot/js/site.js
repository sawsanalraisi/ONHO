$(function () {
    var PlaceHolder = $('#PlaceHolderHere');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        console.log('a[data-toggle=ajax-modal] is clicked');
        var url = $(this).data('url');
    //    $.ajax({
    //        url: url,
    //        type: 'GET', //send it through get method
    //        data: {
    //            vehicleId: pId,
    //        },
    //        dataType: 'text',
    //        success: function (response) {
    //            // Do Something
    //            PlaceHolder.html(response);
    //            PlaceHolder.find('.modal').modal('show');
    //        },
    //        error: function (xhr) {
    //            // Do Something to handle error
    //        },
    //    });
    });
})