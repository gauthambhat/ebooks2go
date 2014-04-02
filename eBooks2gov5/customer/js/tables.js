// JavaScript Document
$(document).ready(function(e) {
    	$('#search').on('keyup', function() {
    var value = $(this).val();

    $('#dataTable tr').each(function(index) {
        if (index !== 0) {

            $row = $(this);

            var id = $row.find('td:first').text();

            if (id.indexOf(value) !== 0) {
                $row.hide();
            }
            else {
                $row.show();
            }
        }
    });
});
});