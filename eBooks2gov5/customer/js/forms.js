// JavaScript Document
$(document).ready(function(e) {
    var intervalFunc = function(){
		$('.bankinfo').css('display','none');
		$('.fileInput').html($('.fileInput').val());	
	}
	$('#upload_avtar').click(function(e) {
        $('.fileInput').click();
		setInterval(intervalFunc,1);
		return false;
    });
});

function userTypeChange(e){
	$('table.users').css('display','table');
 $('input[type=radio][name=pay_mode]').prop('checked', false);
 $('input[type=radio][name = paypalNumbers]').prop('checked', false);
if($('#type').val() == 0) {
		  $('.bankinfo').css('display', 'none');
		  $('#select_royelty').css('display','none');	
		  $('#bankandtaxinfo').css('display','none');	
		  $('#btn_addBank').css('display','none');
		  $('.payPal_numbers').css('display','none');
		   $('.bank_numbers').css('display','none');
		    $('#bank_account_type').css('display','none');
		}
	else if($('#countrySelect').val()!=0){
		
			$('#select_royelty').css('display', 'none');
			$('#bankandtaxinfo').css('display','table-row');
			$('.bankinfo').css('display','none');
			$('#btn_addBank').css('display','none');
			$('.paypalInfo').css('display','none');
			$('.payPal_numbers').css('display','table-row');
		}
		else{
			
			$('#select_royelty').css('display', 'table-row');
			$('#bankandtaxinfo').css('display','table-row');
			$('.bankinfo').css('display','none');
			$('#btn_addBank').css('display','none');
			$('.paypalInfo').css('display','none');
		}
};

function scrollTop(){
	$('html').scrollTop(20);	
}