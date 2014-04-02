// JavaScript Document

$(document).ready(function(e) {
	   $('.paypalInfo').css('display','none');
      $('#select_royelty').css('display','none');
	   $('.payPal_numbers').css('display','none');
	    $('.bank_numbers').css('display','none');
		$('#bank_account_type').css('display', 'none');
		$('.bankinfo').css('display','none');
		//$('#btn_addBank').css('display','none');
		$('#bankShareTD').css('display', 'none');
	    $('#bankShareTH').css('display', 'none');
 
 
 $('input[type=radio][name=bank_numbers]').change(function(){
	  
	 if(this.value == 0){
		 $('#btn_addBank').css('display','none');
		 $('#bank_account_type').css('display', 'table-row');
		  $('#btn_addBank').css('display', 'none');
		  $('.tableBtn_bankAdd').css('display', 'none');
		  $('.bankCount').css('display','none');
		   while($('.bankinfo').length > 1){
			  
			  $('.bankinfo:last').remove();
		  }
		  j = 1;
	 }
	 else{
		 $('#bank_account_type').css('display', 'none');
		 $('#bankandtaxinfo').css('display','table-row');
		 $('#company_info').css('display', 'none');
		 $('.tableBtn_bankAdd').css('display', 'table');
		 $('.bankCount').css('display','block');
		
		  
		   while($('.bankinfo').length > 1){
			  
			  $('.bankinfo:last').remove();
		  }
		  j = 1;
	 }
 });
 
});

$(document).ready(function(e) {
	
	$('input[type = radio][name = bank_numbers]').change(function(){
	 if(this.value == 0){
		 $('.bankinfo').css('display', 'block');
		 $('#bankShareTD').css('display', 'none');
		 $('#bankShareTH').css('display', 'none');
		 $('.bankCount').css('display','none');
	 }
	 else{
		
		 $('.bankinfo').css('display', 'block');
		  $('#bank_account_type').css('display', 'table-row');
		 $('#bankShareTD').css('display', 'table-cell');
		 $('#bankShareTH').css('display', 'table-cell');
		 $('#btn_addBank').css('display','block');
	 }
 });
 
    
});


$(document).ready(function(e) {
     $('input[type=radio][name=accountType]').change(function(){
		  while($('.bankinfo').length > 1){
			  
			  $('.bankinfo:last').remove();
		  }
		  j = 1;
		 if(this.value == 0){
			 $('input[type=radio][name = bank_numbers]').prop('checked', false);
			 $('.personInfo').css('display','none');
			  $('.bankinfo').css('display','block');
			  $('#bank_account_type').css('display','table-row');
			  $('#btn_addBank').css('display','none');
			   $('.bank_numbers').css('display','none');
			    $('#bankShareTD').css('display', 'none');
		 $('#bankShareTH').css('display', 'none');
		 $('.bankCount').css('display', 'none');
		 }
		 else{
			 $('.bankinfo').css('display','none');
			 $('.bank_numbers').css('display','table-row');
			 $('#bankShareTD').css('display', 'table-cell');
		 $('#bankShareTH').css('display', 'table-cell');
		  $('.personInfo').css('display','table-row');
		  $('#company_info').css('display','none');
			 
		 }
	 });
});

 var i = 1;

function dupPaypal(){ 
if(i < 35){
		$('.paypal_info:last').clone().insertAfter('.paypal_info:last');
		i++;
		$('.paypalCount:last').text(i + '. ');
		$('.paypal_info:last').attr('id', 'paypal' + i);
		$('.paypal_info:last input[type="text"]').val('');
	}
};

var j = 1;

function dupBank(){
	if(j < 35){
		$('.bankinfo').animate({'height':'3em'});
		$('.bankinfo:last').clone().insertAfter('.bankinfo:last');
		$('.bankinfo:last input[type="text"]').val('');
		$('.bankinfo:last input[type="select"]').val(-1);
		$('.bankinfo:last input[type="radio"]').val(0);
		$('.bankCount:last').text(j+1);
		j++;
	}
	
}

$(document).ready(function(e) {
   $('input[type=radio][name=paypalNumbers]').bind("change", changetonumbers);
   $('input[type=radio][name=same_address]').bind("change", copyaddress);
});
 
$(document).ready(function(e) {
	$('.bank_numbers').css('display','none');
     $('input[type=radio][name=pay_mode]').change(function(){
		 $('.tableBtn_bankAdd').css('display','none');
	 if(this.value == 0){
		 $('input[type=radio][name=paypalNumbers]').prop('checked', false);
		 $('.payPal_numbers').css('display','table-row');
		 $('#btn_addBank').css('display','none');
		  $('#bank_account_type').css('display','none');
		  $('.bank_numbers').css('display', 'none');
		  $('.bankinfo').css('display', 'none');
		  $('.paypalInfo').css('display', 'none');
	 }
	 else{
		$('input[type=radio][name = accountType]').prop('checked', false);
		  $('.paypalInfo').css('display','none');
		  $('.payPal_numbers').css('display','none');
		  $('.bank_numbers').css('display','none');
		  $('#bank_account_type').css('display', 'table-row');
		  $('.bankinfo').css('display','none');
	 }
	 
 });
});

function changetonumbers(){
	   if(this.value == 0){
			while($('.paypal_info').length > 2)
			{
				$('.paypal_info:last').remove();
			}
			i = 1;
			$('.paypalInfo').css('display','table');
			$('#shareTD').css('display','none');
			$('#addbtn_paypal').css('display','none');
			$('.paypalCount').hide();

	}
	else{
		$('.paypalCount').show();
		$('.paypalInfo').css('display','table');
		$('#addbtn_paypal').css('display','block');
		$('#shareTD').css('display','table-cell');
		while($('.paypal_info').length > 2)
			{
				$('.paypal_info:last').remove();
			}
			i = 1;
		
	}
   }
   
    function displayPayTypes(e){
		$('#type').val(0); 
		 $('.bankinfo').css('display', 'none');
		 $('#select_royelty').css('display','none');	
		 $('#bankandtaxinfo').css('display','none');	
		 $('#btn_addBank').css('display','none');
		 $('.payPal_numbers').css('display','none');
		  $('.bank_numbers').css('display','none');
		  $('#bank_account_type').css('display','none');  
   }

function copyaddress(){
	if(this.value == 0){
		$('#t_line1').val($('#mail1').val());
		$('#t_line2').val($('#mail2').val());
		$('#t_city').val($('#city').val());
		$('#t_country').val($('#countrySelect').val());
		$('#t_state').val($('#state').val());
		
		$('#t_zip').val($('#zip').val());
		$('#t_phone').val($('#phone').val());
		$('#t_fax').val($('#fax').val());
	}
	else{
		$('#t_line1').val('');
		$('#t_line2').val('');
		$('#t_city').val('');
		$('#t_country').val(-1);
		$('#t_state').val(-1);
		
		$('#t_zip').val('');
		$('#t_phone').val('');
		$('#t_fax').val('');
	}
}