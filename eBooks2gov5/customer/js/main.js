// JavaScript Document


 	$(document).ready(function() {
			
            $('.tooltip').tooltipster(
				{
					position: 'right',
					animation: 'swing',
					touchDevices: false,
				}
			
			);
			
			 $('.notification').tooltipster(
				{
					position: 'bottom',
					animation: 'swing',
					touchDevices: false,
				}
			
			);
			
	});
		
			function showHideAdmin(e){
				if($('.adminDown').css('display') == 'none'){
				
				$('.adminDown').css({"display":"block","opacity":0}).animate({"opacity":"1"},1000);
				}
				else{
					$('.adminDown').css('display','none');	
				}
		}
			
			$(document).click(function(e) {
                if(e.target.className != 'adminSection'){
					$('.adminDown').css('display','none');
				}
            });